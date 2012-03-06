using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    /// <summary>
    /// Interface to be implemented by maze solvers.
    /// </summary>
    public interface IMazeSolver
    {
        /// <summary>
        /// Tries to solve the provided maze.
        /// </summary>
        /// <param name="m">Maze to solve.</param>
        /// <param name="formatter">Formatter to use when creating
        /// the solution steps.</param>
        /// <returns>True if the maze is solvable, false otherwise.</returns>
        bool SolveMaze(Maze m, ISolutionFormatter formatter);

        /// <summary>
        /// Returns a string with the steps taken
        /// by the maze solver.
        /// </summary>
        /// <returns>String with steps taken by the maze solver.</returns>
        string GetMazeSteps();

        /// <summary>
        /// Returns a series of ASCII-graphs depicting
        /// the steps taken by the maze solver.
        /// </summary>
        /// <returns>List with ASCII-graph steps taken by the maze solver.</returns>
        List<String> GetGraphicalMazeSteps();
    }
}
