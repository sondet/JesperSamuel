using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelloLibrary
{
    class Artist
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Artist()
        {
            FirstName = "No first name";
            LastName = "No last name";
        }

        public Artist(string firstName, string lastName)
        {
            if (firstName == null || lastName == null) throw new ArgumentNullException();
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return FirstName.ToString() + LastName.ToString();
        }

    }
}
