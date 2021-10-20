using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionsConsole
{
    public class Peg
    {
        public string  Name { get; set; }
        public int Index { get; private set; }
        private static int Counter = 0;
        public bool[] array;
        public Peg(string name, int numdiscs)
        {
            Name = name;
            Index = Counter++;
            array = new bool[numdiscs];
        }

        public Peg(string name)
        {
            Name = name;
            Index = Counter++;
        }
        
    }
}
