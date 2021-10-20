using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InstructionsConsole
{
     public class TowerSolver
    {
        public List<HanoiInstruction> instructions = new List<HanoiInstruction>();

        public void PrintInstruction()
        {
            var temp =0;
            while (temp != instructions.Capacity-1)
            {
                Console.WriteLine($"Move Disk {instructions[temp].Index} From {instructions[temp].FromPeg.Name} To {instructions[temp].ToPeg.Name}");
                temp++;
            }
        }

        public void GenerateInstruction(int disk, Peg start, Peg auxillary, Peg end)
        {
            if (start.Index == auxillary.Index || auxillary.Index == end.Index || start.Index == end.Index) throw new InvalidOperationException("Peg indexes must be unique");
            if (disk == 1)
            {
                instructions.Add(new HanoiInstruction(disk, start, end));
                
            }
            else
            {
                GenerateInstruction(disk - 1, start, end, auxillary);

                instructions.Add(new HanoiInstruction(disk, start, end));


                GenerateInstruction(disk - 1, auxillary, start, end);
            }
        }
    }
}
