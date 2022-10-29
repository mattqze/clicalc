using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            switch(args[0])
            {
                case "add":
                    string numadd1 = args[1];
                    string numadd2 = args[2];
                    int addf = Int32.Parse(numadd1);
                    int addg = Int32.Parse(numadd2);
                    int addh = addf + addg;
                    Console.WriteLine(addh);
                    File.AppendAllText("history.calc",numadd1+" + "+numadd2+" = "+addh + "\n");
                break;

                case "subtract":
                    string numsub1 = args[1];
                    string numsub2 = args[2];
                    int subf = Int32.Parse(numsub1);
                    int subg = Int32.Parse(numsub2);
                    int subh = subf - subg;
                    Console.WriteLine(subh);
                    File.AppendAllText("history.calc", numsub1 + " - " + numsub2 + " = " + subh + "\n");
                break;

                case "multiply":
                    string nummul1 = args[1];
                    string nummul2 = args[2];
                    int mulf = Int32.Parse(nummul1);
                    int mulg = Int32.Parse(nummul2);
                    int mulh = mulf * mulg;
                    Console.WriteLine(mulh);
                    File.AppendAllText("history.calc", nummul1 + " × " + nummul2 + " = " + mulh + "\n");
                break;

                case "divide":
                    string numdiv1 = args[1];
                    string numdiv2 = args[2];
                    int divf = Int32.Parse(numdiv1);
                    int divg = Int32.Parse(numdiv2);
                    int divh = divf / divg;
                    Console.WriteLine(divh);
                    File.AppendAllText("history.calc", numdiv1 + " ÷ " + numdiv2 + " = " + divh+"\n");
                break;

                case "squareroot":
                    string numsqr = args[1];
                    int sqr = Int32.Parse(numsqr);
                    double root = Math.Sqrt(sqr);
                    Console.WriteLine(root);
                    File.AppendAllText("history.calc", "√" + sqr+ " = "+root);
                break;

                case "history":
                    if(args[1] == "show")
                    {
                        Console.WriteLine(File.ReadAllText("history.calc"));
                        break;
                    }
                    if (args[1] == "clear")
                    {
                        File.WriteAllText("history.calc", "");
                        Console.WriteLine("History cleared!");
                        break;
                    }
                    break;

                default:
                    Console.WriteLine("Error!");
                break;
            }
        }
    }
}
