using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    /// <summary>
    /// This interface is used by classes that provide
    /// a way to visualize the solver's steps.
    /// </summary>
    public interface ISolutionFormatter
    {
        /// <summary>
        /// Records a step taken in the maze.
        /// </summary>
        /// <param name="coord">Current coordinate.</param>
        void RecordStep(MazeCoordinate coord);

        /// <summary>
        /// Creates the strings with steps taken to solve the maze.
        /// </summary>
        /// <param name="m">Solved maze.</param>
        /// <param name="simple">Simple list of steps.</param>
        /// <param name="graphical">Graphical list of steps</param>
        void CreateSteps(Maze m,
            out string simple,
            out List<string> graphical);
    }
}
