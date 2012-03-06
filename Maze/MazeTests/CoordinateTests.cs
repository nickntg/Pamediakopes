using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Maze;

namespace MazeTests
{
    [TestClass]
    public class CoordinateTests
    {
        /// <summary>
        /// Verify coordinate object equality.
        /// </summary>
        [TestMethod]
        public void TestCoordinates()
        {
            MazeCoordinate coord1 = new MazeCoordinate(1, 1);
            MazeCoordinate coord2 = new MazeCoordinate(1, 1);
            MazeCoordinate coord3 = new MazeCoordinate(2, 2);
            Assert.AreEqual(coord1, coord2);
            Assert.AreNotEqual(coord1, coord3);
        }
    }
}
