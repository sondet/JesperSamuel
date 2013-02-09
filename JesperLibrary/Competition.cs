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
        public Competition(bool isFinal, string[] artists, string[] songTitles)
        {
            this.IsFinal = isFinal;
            this.artists = artists;
            this.songTitles = songTitles;
        }

    }
}
