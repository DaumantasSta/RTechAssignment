using ReizTechHWAssignment.Models;
using System;

namespace ReizTechHWAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n 1 - Analogue clock. \n 2 - Branch \n 9 - exit application \n");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("\n" + "Analogue Clock");

                        Console.WriteLine("Please input hours (0-12)");
                        int hours = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Please input minutes(0-60)");
                        int minutes = Convert.ToInt32(Console.ReadLine());

                        if (hours < 0 || minutes < 0 || hours > 12 || minutes > 60)
                        {
                            Console.WriteLine("\n" + "Bad analog clock input");
                        }
                        else
                        {
                            var clockAngle = AnalogClockAngle(hours, minutes);
                            Console.WriteLine("\n" + "Smallest angle of analog clock: {0}", 
                                Math.Min(clockAngle, 360 - clockAngle));
                        }

                        break;

                    case "2":
                        Console.WriteLine("\n" + "Branch");

                        var branch = new Branch();
                        branch.branches.Add(new Branch());
                        branch.branches.Add(new Branch());
                        branch[0].branches.Add(new Branch());
                        branch[1].branches.Add(new Branch());
                        branch[1].branches.Add(new Branch());
                        branch[1].branches.Add(new Branch());
                        branch[1][0].branches.Add(new Branch());
                        branch[1][1].branches.Add(new Branch());
                        branch[1][1].branches.Add(new Branch());
                        branch[1][1][0].branches.Add(new Branch());

                        Console.WriteLine("\n" + "Branch depth: {0}", MaxDepth(branch));
                        break;

                    case "9":
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Wrong command");
                        break;
                }
            }
        }

        public static double AnalogClockAngle(int hours, int minutes)
        {
            if (hours == 12)
                hours = 0;

            if (minutes == 60)
                minutes = 0;

            //Hour - 0.5° / min | Minute - 6° / min
            var hoursAngle = 0.5 * (hours * 60 + minutes);
            var minutesAngle = 6 * minutes;

            return Math.Abs(hoursAngle - minutesAngle);
        }

        public static int MaxDepth(Branch branch)
        {
            if (branch == null)
            {
                return 0;
            }

            int max = 0;

            for (int i = 0; i < branch.branches.Count; i++)
            {
                max = Math.Max(max, MaxDepth(branch.branches[i]));
            }

            return max + 1;
        }
    }
}
