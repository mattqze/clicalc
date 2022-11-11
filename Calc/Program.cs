using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Calc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "help")
            {
                Console.WriteLine("Operators: \n\tAddition: add\n\tSubtraction: subtract\n\tMultiplication: multiply\n\tDivision: divide\n\tSquare Root: squareroot\n\tPercent: percentof");
                Console.WriteLine("How to use:\n\tTo use CLI-Calc, you first need to understand the options. \n\tAbove this are all the calculations you can currently do.\n\tBelow this is instructions for each operator.\n\tIf you run into a bug, use the bug reporting command below.\n\tcalc report error\n\tTo update: calc update \nHow to input data:\n\tadd: calc add num1 num2\n\tsubtract: calc subtract num1 num2\n\tdivide: calc divide num1 num2\n\tmultiply: calc multiply num1 num2\n\tsquareroot: calc squareroot num1\n\tpercentof: calc num1 percentof num2");
                Console.WriteLine("History Control:\n\tShow History: calc history show\n\tClear History: calc history clear\n\tShow Error History: calc error history show\n\tClear Error History (NOT RECOMMENDED): calc error history clear");
                return;
            }
            if(args[0] == "update")
            {
                WebClient client = new WebClient();
                string asd = client.DownloadString("https://github.com/mattqze/clicalc/releases/latest/download/changelog.txt");
                Console.WriteLine("Update Log for latest release:\n" + asd);
                Console.WriteLine("Would you like to update? [Y/N]");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    System.Diagnostics.Process.Start("https://github.com/mattqze/clicalc/releases/latest/");
                    return;
                }
                if (keyInfo.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Canceled Update");
                }
                if (keyInfo.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Canceled Update");
                }
                return;
            }
            if (args[1] == "percentof")
            {
                string one = args[0];
                string two = args[2];
                double a = Int32.Parse(one);
                double b = Int32.Parse(two);
                double d = a / 100 * b;
                Console.WriteLine(d);
                return;
            }
            switch (args[0])
            {
                case "add":
                    string numadd1 = args[1];
                    string numadd2 = args[2];
                    int addf = Int32.Parse(numadd1);
                    int addg = Int32.Parse(numadd2);
                    int addh = addf + addg;
                    Console.WriteLine(addh);
                    string fullhistory = string.Join(" ", args);
                    File.AppendAllText("cmdhistory.calc", fullhistory + "\n");
                    File.AppendAllText("history.calc",numadd1+" + "+numadd2+" = "+addh + "\n");
                break;

                case "subtract":
                    string numsub1 = args[1];
                    string numsub2 = args[2];
                    int subf = Int32.Parse(numsub1);
                    int subg = Int32.Parse(numsub2);
                    int subh = subf - subg;
                    Console.WriteLine(subh);
                    fullhistory = string.Join(" ", args);
                    File.AppendAllText("cmdhistory.calc", fullhistory + "\n");
                    File.AppendAllText("history.calc", numsub1 + " - " + numsub2 + " = " + subh + "\n");
                break;

                case "multiply":
                    string nummul1 = args[1];
                    string nummul2 = args[2];
                    int mulf = Int32.Parse(nummul1);
                    int mulg = Int32.Parse(nummul2);
                    int mulh = mulf * mulg;
                    Console.WriteLine(mulh);
                    fullhistory = string.Join(" ", args);
                    File.AppendAllText("cmdhistory.calc", fullhistory + "\n");
                    File.AppendAllText("history.calc", nummul1 + " × " + nummul2 + " = " + mulh + "\n");
                break;

                case "divide":
                    string numdiv1 = args[1];
                    string numdiv2 = args[2];
                    double divf = Int32.Parse(numdiv1);
                    double divg = Int32.Parse(numdiv2);
                    double divh = divf / divg;
                    Console.WriteLine(divh);
                    fullhistory = string.Join(" ", args);
                    File.AppendAllText("cmdhistory.calc", fullhistory + "\n");
                    File.AppendAllText("history.calc", numdiv1 + " ÷ " + numdiv2 + " = " + divh+"\n");
                break;

                case "squareroot":
                    string numsqr = args[1];
                    int sqr = Int32.Parse(numsqr);
                    double root = Math.Sqrt(sqr);
                    Console.WriteLine(root);
                    fullhistory = string.Join(" ", args);
                    File.AppendAllText("cmdhistory.calc", fullhistory + "\n");
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
                        Console.WriteLine("Are you sure you would like to clear calculator history? [Y/N]");
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        if(keyInfo.Key == ConsoleKey.Y)
                        {
                            File.WriteAllText("history.calc", "");
                            Console.WriteLine("History cleared!");
                            break;
                        }
                        if(keyInfo.Key == ConsoleKey.N)
                        {
                            Console.WriteLine("Canceled");
                            break;
                        }
                        if(keyInfo.Key != ConsoleKey.N)
                        {
                            Console.WriteLine("Canceled");
                            break;
                        }
                    }
                    break;
                case "error":
                    if (args[1] == "history")
                    {
                        if (args[2] == "clear")
                        {
                            Console.WriteLine("WARNING: THIS HISTORY INCLUDES ERRORS WHICH ARE USED AS BUG REPORTS. \nPLEASE DO NOT DELETE BEFORE CHECKING FOR ERRORS USING \"calc error history show\"\nPress Enter to Continue.");
                            Console.ReadLine();
                            Console.WriteLine("Are you sure you would like to clear in-depth calculator history? [Y/N]");
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            if (keyInfo.Key == ConsoleKey.Y)
                            {
                                File.WriteAllText("cmdhistory.calc", "");
                                Console.WriteLine("History cleared!");
                                break;
                            }
                            if (keyInfo.Key == ConsoleKey.N)
                            {
                                Console.WriteLine("Canceled");
                                break;
                            }
                            if (keyInfo.Key != ConsoleKey.N)
                            {
                                Console.WriteLine("Canceled");
                                break;
                            }
                        }
                        if (args[1] == "show")
                        {
                            Console.WriteLine(File.ReadAllText("cmdhistory.calc"));
                            break;
                        }
                    }
                    break;
                case "report":
                    if (args[1] == "error")
                    {
                        System.Diagnostics.Process.Start("https://forms.gle/WpjmoimpLpsJAMUG7");
                    }
                    break;
                default:
                    fullhistory = string.Join(" ", args) + " #CAUSEDERROR\n";
                    File.AppendAllText("cmdhistory.calc", fullhistory);
                    Console.WriteLine("Error!");
                break;
            }
        }
    }
}
