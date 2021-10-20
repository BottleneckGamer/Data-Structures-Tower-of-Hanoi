using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new TowerSolver();
            var pA = new Peg("A");
            var pB = new Peg("B");
            var pC = new Peg("C");
            Peg startPeg = new Peg(""), endPeg = new Peg(""), auxPeg = new Peg("");
            Console.Write("# of disks: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("1 - Peg A");
            Console.WriteLine("2 - Peg B");
            Console.WriteLine("3 - Peg C");
            Console.WriteLine("start peg: ");
            string sPeg = Console.ReadLine();
            Console.WriteLine("1 - Peg A");
            Console.WriteLine("2 - Peg B");
            Console.WriteLine("3 - Peg C");
            Console.WriteLine("end peg: ");
            string ePeg = Console.ReadLine();
            switch (sPeg)
            {
                case "1":
                {
                    startPeg = pA;
                    break;
                }
                case "2":
                {
                    startPeg = pB;
                    break;
                }
                case "3":
                {
                    startPeg = pC;
                    break;
                }
            }
            switch (ePeg)
            {
                case "1":
                {
                    endPeg = pA;
                    break;
                }
                case "2":
                {
                    endPeg = pB;
                    break;
                }
                case "3":
                {
                    endPeg = pC;
                    break;
                }
            }

            if (startPeg == pA && endPeg == pB)
            {
                auxPeg = pC;
            }
            else if (startPeg == pA && endPeg == pC)
            {
                auxPeg = pB;
            }
            else if (startPeg == pB && endPeg == pA)
            {
                auxPeg = pC;
            }
            else if (startPeg == pB && endPeg == pC)
            {
                auxPeg = pA;
            }
            else if (startPeg == pC && endPeg == pA)
            {
                auxPeg = pB;
            }
            else if (startPeg == pC && endPeg == pB)
            {
                auxPeg = pA;
            }

            x.GenerateInstruction(y, startPeg,auxPeg,endPeg);
            Console.WriteLine("");
            Console.WriteLine("Instructions:");
            x.PrintInstruction();
            Console.ReadKey();
        }
    }
}
