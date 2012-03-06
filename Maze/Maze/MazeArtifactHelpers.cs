using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    /// <summary>
    /// This class contains artifact helper methods.
    /// </summary>
    public class MazeArtifactHelpers
    {
        private const string FINISH = "G";
        private const string START = "S";
        private const string WALL = "X";
        private const string ROAD = "_";

        /// <summary>
        /// Coverts an artifact to a string.
        /// </summary>
        /// <param name="artifact">Artifact to convert.</param>
        /// <returns>Converted artifact.</returns>
        public static string ToString(MazeArtifact artifact)
        {
            switch (artifact)
            {
                case MazeArtifact.Finish:
                    return FINISH;
                case MazeArtifact.Road:
                    return ROAD;
                case MazeArtifact.Start:
                    return START;
                case MazeArtifact.Wall:
                    return WALL;
                default:
                    throw new InvalidCastException(string.Format("Invalid artifact {0}", artifact.ToString()));
            }
        }

        /// <summary>
        /// Converts a string to an artifact.
        /// </summary>
        /// <param name="s">String to convert.</param>
        /// <returns>Artifact constructed from string.</returns>
        public static MazeArtifact FromString(string s)
        {
            switch (s)
            {
                case FINISH:
                    return MazeArtifact.Finish;
                case START:
                    return MazeArtifact.Start;
                case WALL:
                    return MazeArtifact.Wall;
                case ROAD:
                    return MazeArtifact.Road;
                default:
                    throw new InvalidCastException(string.Format("Invalid artifact representation {0}", s));
            }
        }
    }
}
