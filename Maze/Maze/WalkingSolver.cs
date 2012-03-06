using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    /// <summary>
    /// Implements a simple walking maze solver. This simply tries to move around in a pre-determined
    /// fashion until it finds the maze finish. When the solver dead-ends, it backtracks along its
    /// original path and, if possible, tries to continue to another direction.
    /// 
    /// The limiting factor here is the following requirement:
    ///     "Please, note that robot can only see one step ahead only (top, bottom, left, right). No more. Does not know where the Goal is, either."
    /// 
    /// This means that we cannot use a simple, breadth-first map solving algorithm; this would mean
    /// that we traverse every possible artifact of the maze and then provide the shortest path. This
    /// requirement, however, indicates implicitly that the robot needs to be moved in order to see
    /// one step ahead. Hence this implementation.
    /// 
    /// </summary>
    public class WalkingSolver : IMazeSolver
    {
        string mazeSteps;
        List<String> mazeGraphSteps;
        ISolutionFormatter formatter;

        /// <summary>
        /// Solves the maze by walking it.
        /// </summary>
        /// <param name="m">Maze to solve.</param>
        /// <param name="formatter">Formatter to use when creating
        /// the solution steps.</param>
        /// <returns>True if maze is solveable, false otherwise.</returns>
        public bool SolveMaze(Maze m, ISolutionFormatter formatter)
        {
            mazeSteps = string.Empty;
            mazeGraphSteps = new List<string>();
            this.formatter = formatter;

            // Find the beggining.
            MazeCoordinate start = m.StartingPoint;

            // Solve the maze.
            MazeCoordinate coord = RecursiveSolve(m, start);
            if (coord != null)
            {
                formatter.CreateSteps(m, out mazeSteps, out mazeGraphSteps);
            }

            return (coord != null);
        }

        /// <summary>
        /// Return the steps taken to solve the maze.
        /// </summary>
        /// <returns>String representation with steps taken.</returns>
        public string GetMazeSteps()
        {
            return mazeSteps;
        }

        /// <summary>
        /// Return a graphical list of steps taken to solve the maze.
        /// </summary>
        /// <returns>Graphical list of steps taken to solve the maze.</returns>
        public List<string> GetGraphicalMazeSteps()
        {
            return mazeGraphSteps;
        }

        /// <summary>
        /// Recursively solves the maze.
        /// </summary>
        /// <param name="m">Maze to solve.</param>
        /// <param name="coord">Current position.</param>
        /// <returns>Coordinate with finish or null if the algorithm dead-ended.</returns>
        private MazeCoordinate RecursiveSolve(Maze m, MazeCoordinate coord)
        {
            // Indicate we've visited this position.
            m.GetPosition(coord).Visited = true;

            //...and record our step.
            formatter.RecordStep(coord);

            // If we're finished, return this coordinate.
            if (m.GetPosition(coord).Artifact == MazeArtifact.Finish)
            {
                return coord;
            }

            MazeCoordinate nextCoord = null;

            // Start looking around.
            for (Direction dir = Direction.Up; dir <= Direction.Down; dir++)
            {
                MazePosition next = m.PeekToDirection(coord, dir);

                // Can we go towards that direction?
                if (TryNext(next))
                {
                    // If yes, try to solve from there.
                    nextCoord = RecursiveSolve(m, next.Coordinate);
                    if (nextCoord != null)
                    {
                        // Solution reached.
                        return nextCoord;
                    }

                    // Backtrack.
                    formatter.RecordStep(coord);
                }
            }

            return null;
        }

        /// <summary>
        /// See if we can go towards a specific position.
        /// </summary>
        /// <param name="pos">Position to check.</param>
        /// <returns>True if the robot can move towards this position,
        /// false otherwise.</returns>
        private bool TryNext(MazePosition pos)
        {
            return (pos != null && pos.Artifact != MazeArtifact.Wall && !pos.Visited);
        }
    }
}
