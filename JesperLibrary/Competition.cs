using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelloLibrary
{
    public class Competition
    {
        public bool IsFinal 
        { get; set; }
        public string[] artists
        { get; set; }
        public string[] songTitles
        { get; set; }
        /// <summary>
        /// Class that stores data describing a competition in Melodifestivalen.
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

        public static Competition CreateFromFile(string fileName)
        {



            //TODO: static method to create a competition object from a file
            throw new NotImplementedException();
        }

    }
}
