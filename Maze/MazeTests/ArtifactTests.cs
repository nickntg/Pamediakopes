using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Maze;

namespace MazeTests
{
    [TestClass]
    public class ArtifactTests
    {
        /// <summary>
        /// Verify that all conversions between strings and artifacts are valid.
        /// </summary>
        [TestMethod]
        public void TestConversions()
        {
            Assert.AreEqual(MazeArtifact.Wall, MazeArtifactHelpers.FromString("X"));
            Assert.AreEqual(MazeArtifact.Road, MazeArtifactHelpers.FromString("_"));
            Assert.AreEqual(MazeArtifact.Start, MazeArtifactHelpers.FromString("S"));
            Assert.AreEqual(MazeArtifact.Finish, MazeArtifactHelpers.FromString("G"));

            Assert.AreEqual("X", MazeArtifactHelpers.ToString(MazeArtifact.Wall));
            Assert.AreEqual("_", MazeArtifactHelpers.ToString(MazeArtifact.Road));
            Assert.AreEqual("S", MazeArtifactHelpers.ToString(MazeArtifact.Start));
            Assert.AreEqual("G", MazeArtifactHelpers.ToString(MazeArtifact.Finish));
        }

        /// <summary>
        /// Verify that an invalid string throws an InvalidCastException
        /// when trying to create an artifact from it.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void TestFailedConversion1()
        {
            MazeArtifactHelpers.FromString("0");
        }

        /// <summary>
        /// Verify that an invalid enumeration value throws an InvalidCastException
        /// when a string representation is created.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void TestFailedConversion2()
        {
            MazeArtifactHelpers.ToString((MazeArtifact)100);
        }
    }
}
