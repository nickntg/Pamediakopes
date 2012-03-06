using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    /// <summary>
    /// This class is used to define a point in the maze.
    /// </summary>
    public class MazeCoordinate
    {
        /// <summary>
        /// Get/set the x coordinate.
        /// </summary>
        public int x { get; set; }

        /// <summary>
        /// Get/set the y coordinate.
        /// </summary>
        public int y { get; set; }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        public MazeCoordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Override equality to check for same coordinates.
        /// </summary>
        /// <param name="obj">Other coordinate instance.</param>
        /// <returns>True if both instances refer to the same coordinate,
        /// false otherwise</returns>
        public override bool Equals(object obj)
        {
            MazeCoordinate otherObj = (MazeCoordinate)obj;
            return (this.x == otherObj.x && this.y == otherObj.y);
        }

        /// <summary>
        /// Override this as well.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
