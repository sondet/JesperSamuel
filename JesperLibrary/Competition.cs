using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MelloLibrary
{
    /// <summary>
    /// Class that stores data describing a competition in Melodifestivalen.
    /// </summary>
    public class Competition
    {
        public bool IsFinal 
        { get; set; }
        public string[] artists
        { get; set; }
        public string[] songTitles
        { get; set; }

        public string City { get; set; }
        public int CompetitionNumber { get; set; }

        private Dictionary<int, Song> mSongs;
        public Dictionary<int, Song> Songs {
            get { return mSongs; }
            set { mSongs = value; }
        }

        /// <summary>
        /// Constructor - Creates an empty competition
        /// </summary>
        public Competition()
        {
            IsFinal = false;
            mSongs = new Dictionary<int, Song>(10);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isFinal">Property that describes if the competition is the final one</param>
        /// <param name="artists">Array of Strings with artists</param>
        /// <param name="songTitles">Array of strings with song titles.</param>
        public Competition(bool isFinal, string[] artists, string[] songTitles)
        {
            this.IsFinal = isFinal;
            this.artists = artists;
            this.songTitles = songTitles;
        }

        public static List<Competition> CreateFromFile(string fileName)
        {
            List<Competition> competitions = new List<Competition>();
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(Directory.GetCurrentDirectory() + "\\" + fileName);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("INGEN FIL: " + e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            string line = "";

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(';');
                if (parts[0].Equals("Competition"))
                {
                    Competition comp = new Competition();
                    switch (parts.Length)
                    {
                        case 3:
                            comp.City = parts[1];
                            comp.CompetitionNumber = int.Parse(parts[2]);
                            break;
                        default:
                            throw new FormatException();
                    }

                    string songline = "";
                    int i = 1;
                    while (!(songline = reader.ReadLine()).Equals("#"))
                    {
                        string[] songparts = songline.Split(';');
                        switch (songparts.Length)
                        {
                            case 2:
                                comp.Songs.Add(i, new Song(new Artist(songparts[0]), songparts[1]));
                                break;
                            case 3:
                                comp.Songs.Add(i, new Song(new Artist(songparts[0], songparts[1]), songparts[2]));
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    competitions.Add(comp);
                }

            }
            reader.Close();
            competitions.TrimExcess();
            return competitions;
        }

    }
}
