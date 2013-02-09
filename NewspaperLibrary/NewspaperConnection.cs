using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperLibrary
{
    public class NewspaperConnection
    {
    }

    public class Newspaper
    {
        private Uri mUri;
        public Uri Uri
        {
            get { return mUri; }
            set { mUri = value; }
        }

        private string mName;
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }

        
    }
}

