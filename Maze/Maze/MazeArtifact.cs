using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    /// <summary>
    /// This enumeration defines all artifacts of a maze.
    /// </summary>
    public enum MazeArtifact
    {
        /// <summary>
        /// Starting point.
        /// </summary>
        Start = 0,

        /// <summary>
        /// Finish point.
        /// </summary>
        Finish,

        /// <summary>
        /// Wall.
        /// </summary>
        Wall,

        /// <summary>
        /// Road.
        /// </summary>
        Road
    }
}
