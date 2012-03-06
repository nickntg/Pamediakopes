using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Maze;

namespace MazeTests
{
    [TestClass]
    public class MazeTests
    {
        /// <summary>
        /// Verify that an InvalidOperationException is thrown when
        /// trying to create a maze with an empty string.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyMazeSuppliedTest()
        {
            Maze.Maze m = new Maze.Maze(string.Empty);
        }

        /// <summary>
        /// Verify that an InvalidOperationException is thrown when
        /// trying to create a maze with a null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NullMazeSuppliedTest()
        {
            Maze.Maze m = new Maze.Maze(null);
        }

        /// <summary>
        /// Verify that an InvalidCastException is thrown when
        /// trying to create a maze with invalid sizes.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void InvalidMazeDimensionsTest()
        {
            string m = "__________\r\n" +
                       "__________\r\n" +
                       "___________";
            Maze.Maze maze = new Maze.Maze(m);
        }

        /// <summary>
        /// Verify that an InvalidOperationException is thrown when
        /// trying to create a maze with multiple starting points.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MultipleStartPointsTest()
        {
            string m = "S____G____\r\n" +
                       "__________\r\n" +
                       "_________S";
            Maze.Maze maze = new Maze.Maze(m);
        }

        /// <summary>
        /// Verify that an InvalidOperationException is thrown when
        /// trying to create a maze with no start points.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NoStartPointsTest()
        {
            string m = "_____G____\r\n" +
                       "__________\r\n" +
                       "__________";
            Maze.Maze maze = new Maze.Maze(m);
        }

        /// <summary>
        /// Verify that an InvalidOperationException is thrown when
        /// trying to create a maze with multiple goals.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MultipleFinishPointsTest()
        {
            string m = "_____G____\r\n" +
                       "__G_______\r\n" +
                       "____S_____";
            Maze.Maze maze = new Maze.Maze(m);
        }

        /// <summary>
        /// Verify that an InvalidOperationException is thrown when
        /// trying to create a maze with no goals.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NoGoalPointsTest()
        {
            string m = "__________\r\n" +
                       "__________\r\n" +
                       "____S_____";
            Maze.Maze maze = new Maze.Maze(m);
        }

        /// <summary>
        /// Verify that the maze algorithm understands
        /// when the maze cannot be solved.
        /// </summary>
        [TestMethod]
        public void CannotSolveTests()
        {
            string maze1 = "__________\r\n" +
                           "________XX\r\n" +
                           "S_______XG";

            string maze2 = "S________XG";

            WalkingSolver solver = new WalkingSolver();
            Assert.IsFalse(solver.SolveMaze(new Maze.Maze(maze1), new ASCIIFormatter()));
            Assert.IsFalse(solver.SolveMaze(new Maze.Maze(maze2), new ASCIIFormatter()));
        }

        /// <summary>
        /// Verify that the robot can peek in the maze.
        /// </summary>
        [TestMethod]
        public void DirectionTests()
        {
            string m = "____X_____\r\n" +
                       "____X___XX\r\n" +
                       "S___X___XG";

            Maze.Maze maze = new Maze.Maze(m);
            Assert.IsNull(maze.PeekToDirection(new MazeCoordinate(0, 0), Direction.Left));
            Assert.IsNull(maze.PeekToDirection(new MazeCoordinate(0, 0), Direction.Up));

            Assert.AreEqual(maze.GetPosition(new MazeCoordinate(0, 1)), maze.PeekToDirection(new MazeCoordinate(0, 0), Direction.Down));
            Assert.AreEqual(maze.GetPosition(new MazeCoordinate(1, 0)), maze.PeekToDirection(new MazeCoordinate(0, 0), Direction.Right));

            Assert.IsNull(maze.PeekToDirection(new MazeCoordinate(9, 2), Direction.Right));
            Assert.IsNull(maze.PeekToDirection(new MazeCoordinate(9, 2), Direction.Down));

            Assert.AreEqual(maze.GetPosition(new MazeCoordinate(9, 1)), maze.PeekToDirection(new MazeCoordinate(9, 2), Direction.Up));
            Assert.AreEqual(maze.GetPosition(new MazeCoordinate(8, 2)), maze.PeekToDirection(new MazeCoordinate(9, 2), Direction.Left));
        }

        /// <summary>
        /// Verify that the sample can be solved.
        /// </summary>
        [TestMethod]
        public void SampleSolveTest()
        {
            string m = "_____GX_" + "\r\n" +
                       "____XXX_" + "\r\n" +
                       "________" + "\r\n" +
                       "XXXX____" + "\r\n" +
                       "___X____" + "\r\n" +
                       "S_______";

            WalkingSolver solver = new WalkingSolver();
            Assert.IsTrue(solver.SolveMaze(new Maze.Maze(m), new ASCIIFormatter()));
        }
        
    }
}