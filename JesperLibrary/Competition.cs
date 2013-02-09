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
        
        public Competition(bool isFinal)
        {
            this.IsFinal = isFinal;
        }
    }
}
