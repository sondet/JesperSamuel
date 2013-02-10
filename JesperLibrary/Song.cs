using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelloLibrary
{
    class Song
    {
        public Artist Artist { get; set; }
        public string Title { get; set; }

        public Song()
        {
            Artist = new Artist();
            Title = "No titel";
        }

        public Song(Artist artist, string title)
        {
            if (title == null || artist == null) throw new ArgumentNullException();
            Artist = artist;
            Title = title;
        }

        public override string ToString()
        {
            return Title.ToString() + " :: " + Artist.ToString();
        }
    }
}
