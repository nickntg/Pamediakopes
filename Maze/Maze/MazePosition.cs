using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    /// <summary>
    /// This class is used to hold information about a position of the maze.
    /// </summary>
    public class MazePosition
    {
        /// <summary>
        /// Get/set the artifact of maze position.
        /// </summary>
        public MazeArtifact Artifact { get; set; }

        /// <summary>
        /// Get/set whether the position has been previously visited.
        /// </summary>
        public bool Visited { get; set; }

        /// <summary>
        /// Get/set the position coordinate.
        /// </summary>
        public MazeCoordinate Coordinate { get; set; }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        /// <param name="artifact">Artifact of position.</param>
        /// <param name="coord">Coordinates of position.</param>
        public MazePosition(MazeArtifact artifact, MazeCoordinate coord)
        {
            this.Artifact = artifact;
            this.Coordinate = coord;
            Visited = false;
        }
    }
}
