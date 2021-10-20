using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionsConsole
{
     public class HanoiInstruction
    {
        public int Index { get; set; }
        public Peg FromPeg { get; set; }
        public Peg ToPeg { get; set; }
        
        public HanoiInstruction(int index,Peg fromPeg, Peg toPeg)
        {
            Index = index;
            FromPeg = fromPeg;
            ToPeg = toPeg;
        }
        
    }
}
