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

            //TODO: static method to create a competition object from a file
            throw new NotImplementedException();
        }

    }
}
