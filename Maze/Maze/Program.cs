using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Maze
{
    class Program
    {
        /// <summary>
        /// Main program entry point. Run from the command line
        /// and supply the full or relative path to a maze file.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.GetLength(0) != 1)
            {
                Console.WriteLine("Usage: Maze <Maze file>");
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(args[0]))
                {
                    WalkingSolver solver = new WalkingSolver();
                    if (solver.SolveMaze(new Maze(sr.ReadToEnd()), new ASCIIFormatter()))
                    {
                        Console.WriteLine(solver.GetMazeSteps());

                        int x = Console.CursorLeft;
                        int y = Console.CursorTop;

                        foreach (string s in solver.GetGraphicalMazeSteps())
                        {
                            Console.SetCursorPosition(x, y);
                            Console.WriteLine(s);
                            System.Threading.Thread.Sleep(250);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Maze cannot be solved.");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Invalid maze file specified");
            }
        }
    }
}
