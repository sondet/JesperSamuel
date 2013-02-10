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
        public string GroupName { get; set; }

        public Artist()
        {
            FirstName = "No first name";
            LastName = "No last name";
            GroupName = "No group name";
        }

        public Artist(string firstName, string lastName)
        {
            if (firstName == null || lastName == null) throw new ArgumentNullException();
            FirstName = firstName;
            LastName = lastName;
            GroupName = null;
        }

        public Artist(string groupName)
        {
            if (groupName == null) throw new ArgumentNullException();
            FirstName = null;
            LastName = null;
            GroupName = groupName;
        }

        public override string ToString()
        {
            if (GroupName != null) return GroupName.ToString();
            return FirstName.ToString() + LastName.ToString();
        }

    }
}
