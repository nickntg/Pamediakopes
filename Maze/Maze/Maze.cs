using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    /// <summary>
    /// This class is used to define a maze.
    /// </summary>
    public class Maze
    {
        // Internal maze representation.
        private MazePosition[,] maze;

        /// <summary>
        /// Get the maze starting position.
        /// </summary>
        public MazeCoordinate StartingPoint { get; private set; }

        /// <summary>
        /// Get the width of the maze.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Get the height of the maze.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Returns the maze position of a coordinate.
        /// </summary>
        /// <param name="coord">Maze coordinate.</param>
        /// <returns>Object with maze position information.</returns>
        public MazePosition GetPosition(MazeCoordinate coord)
        {
            return maze[coord.x, coord.y];
        }

        /// <summary>
        /// Creates a new instance of this class from a string.
        /// </summary>
        /// <param name="mazeString">String representing the maze.</param>
        public Maze(string mazeString)
        {
            if (string.IsNullOrEmpty(mazeString))
            {
                throw new InvalidOperationException("Need a string with contents to create a maze");
            }

            // Parse and create the internal representation.
            string[] splitted = mazeString.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            maze = (MazePosition[,])Array.CreateInstance(typeof(MazePosition), new int[] { splitted[0].Length, splitted.GetLength(0) });

            // Validate the dimensions.
            ValidateDimensions(splitted);

            Width = splitted[0].Length;
            Height = splitted.GetLength(0);

            // Create the internal representation.
            for (int y = Height - 1; y >= 0; y--)
            {
                for (int x = 0; x < Width; x++)
                {
                    maze[x, y] = new MazePosition(MazeArtifactHelpers.FromString(splitted[y].Substring(x, 1)), new MazeCoordinate(x, y));
                }
            }

            // Validate start and finish points.
            ValidatePoints();
        }

        /// <summary>
        /// Looks from a maze coordinate towards a direction
        /// and returns the maze position that is there.
        /// </summary>
        /// <param name="coord">Coordinate to look from.</param>
        /// <param name="dir">Direction to look at.</param>
        /// <returns>Maze position looked or null if it's out of the maze bounds.</returns>
        public MazePosition PeekToDirection(MazeCoordinate coord, Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    if (coord.y > 0)
                    {
                        return maze[coord.x, coord.y - 1];
                    }
                    break;
                case Direction.Down:
                    if (coord.y < Height - 1)
                    {
                        return maze[coord.x, coord.y + 1];
                    }
                    break;
                case Direction.Left:
                    if (coord.x > 0)
                    {
                        return maze[coord.x - 1, coord.y];
                    }
                    break;
                default:
                    if (coord.x < Width - 1)
                    {
                        return maze[coord.x + 1, coord.y];
                    }
                    break;
            }
            return null;
        }

        /// <summary>
        /// Checks that all strings representing maze
        /// rows are of the same dimension.
        /// </summary>
        /// <param name="splitted">Maze rows.</param>
        /// <remarks>Throws an InvalidCastException if the validation fails.</remarks>
        private void ValidateDimensions(string[] splitted)
        {
            if (splitted == null)
            {
                throw new InvalidCastException("Cannot initialize with empty maze");
            }

            int len = splitted[0].Length;
            for (int i = 1; i < splitted.GetLength(0); i++)
            {
                if (splitted[i].Length != len)
                {
                    throw new InvalidCastException("Invalid maze supplied");
                }
            }
        }

        /// <summary>
        /// Checks that the maze has one start and finish points.
        /// </summary>
        /// <remarks>Throws an InvalidOperationException if the validation fails.</remarks>
        private void ValidatePoints()
        {
            bool hasFinish = false;

            for (int y = 0; y < maze.GetLength(1); y++)
            {
                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    if (maze[x, y].Artifact == MazeArtifact.Start)
                    {
                        if (StartingPoint == null)
                        {
                            StartingPoint = new MazeCoordinate(x, y);
                        }
                        else
                        {
                            throw new InvalidOperationException("Maze contains more than one start points");
                        }
                    }
                    else if (maze[x, y].Artifact == MazeArtifact.Finish)
                    {
                        if (!hasFinish)
                        {
                            hasFinish = true;
                        }
                        else
                        {
                            throw new InvalidOperationException("Maze contains more than one goals");
                        }
                    }
                }
            }

            if (StartingPoint == null)
            {
                throw new InvalidOperationException("A starting point has not been provided");
            }

            if (!hasFinish)
            {
                throw new InvalidOperationException("A goal has not been provided");
            }
        }

        /// <summary>
        /// Returns a human-readable representation of the maze.
        /// </summary>
        /// <returns>String with human-readable maze representation.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    sb.Append(MazeArtifactHelpers.ToString(maze[x, y].Artifact));
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

    }
}
