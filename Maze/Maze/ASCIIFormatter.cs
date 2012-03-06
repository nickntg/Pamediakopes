using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    /// <summary>
    /// This formatter generates simple ASCII output
    /// displaying the steps taken by a solver.
    /// </summary>
    public class ASCIIFormatter : ISolutionFormatter
    {
        // Create a queue to keep our steps.
        Queue<MazeCoordinate> steps = new Queue<MazeCoordinate>();

        // Keep track of the last step.
        MazeCoordinate lastStep = null;

        /// <summary>
        /// Records a step taken in the maze.
        /// </summary>
        /// <param name="coord">Current coordinate.</param>
        public void RecordStep(MazeCoordinate coord)
        {
            if (lastStep == null || !lastStep.Equals(coord))
            {
                steps.Enqueue(coord);
                lastStep = coord;
            }
        }

        /// <summary>
        /// Creates the strings with steps taken to solve the maze.
        /// </summary>
        /// <param name="m">Solved maze.</param>
        /// <param name="simple">Simple list of steps.</param>
        /// <param name="graphical">Graphical list of steps</param>
        public void CreateSteps(Maze m, 
            out string simple, 
            out List<string> graphical)
        {
            graphical = new List<string>();

            StringBuilder sb1 = new StringBuilder();

            string mazeText = m.ToString();

            while (steps.Count > 0)
            {
                MazeCoordinate coord = steps.Dequeue();
                sb1.AppendLine(string.Format("{0}, {1}", coord.x + 1, m.Height - coord.y));

                int pos = (m.Width + 2) * coord.y + coord.x;
                string player = mazeText.Remove(pos, 1);
                player = player.Insert(pos, "@");
                graphical.Add(player);
            }
            simple = sb1.ToString();
        }
    }
}
