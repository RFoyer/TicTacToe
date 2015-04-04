using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeModel;

namespace TicTacToeTests
{
    [TestClass]
    public class TicTacToeTests
    {
        [TestMethod]
        public void ThreeOs_ReturnsWin()
        {
            Game game = new Game();
            var s = new List<string>() { "O", "O", "O", "X", "X", "", "X", "", "" };
            game.squaresPlayed = s;
            game.letterOfCurrentPlayerSide = "O";
            game.turnNumber = 5;

            var actual = game.setCurrentScoreSituation();

            Assert.AreEqual(ScoreSituation.Win, actual);

        }

        [TestMethod]
        public void ThreeXs_ReturnsWin()
        {
            Game game = new Game();
            var s = new List<string>() { "X", "X", "X", "O", "O", "", "O", "", "" };
            game.squaresPlayed = s;
            game.letterOfCurrentPlayerSide = "X";
            game.turnNumber = 5;

            var actual = game.setCurrentScoreSituation();

            Assert.AreEqual(ScoreSituation.Win, actual);

        }

        [TestMethod]
        public void CatGame_ReturnsDraw()
        {
            Game game = new Game();
            var s = new List<string>() { "X", "X", "O", "O", "O", "X", "X", "O", "O" };
            game.squaresPlayed = s;
            game.letterOfCurrentPlayerSide = "X";
            game.turnNumber = 8;

            var actual = game.setCurrentScoreSituation();

            Assert.AreEqual(ScoreSituation.Draw, actual);

        }

        [TestMethod]
        public void CheckForWinningForkTest1()
        {
            Game game = new Game();
            var s = new List<string>() { "X", "", "O", "", "O", "", "", "", "X" };
            game.squaresPlayed = s;
            game.letterOfCurrentPlayerSide = "X";
            game.turnNumber = 4;
            game.getAiMove();

            var actual = 6;

            Assert.AreEqual(game.currentSquare, actual);
        }

        [TestMethod]
        public void CheckForWinningForkTest2()
        {
            Game game = new Game();
            var s = new List<string>() { "O", "", "X", "", "O", "", "X", "", "" };
            game.squaresPlayed = s;
            game.letterOfCurrentPlayerSide = "X";
            game.turnNumber = 4;
            game.getAiMove();

            var actual = 8;

            Assert.AreEqual(game.currentSquare, actual);
        }

        [TestMethod]
        public void CheckForForkBlockTest1()
        {
            Game game = new Game();
            var s = new List<string>() { "", "", "", "", "O", "X", "", "X", "" };
            game.squaresPlayed = s;
            game.letterOfCurrentPlayerSide = "O";
            game.turnNumber = 3;
            game.getAiMove();

            var actual = 8;

            Assert.AreEqual(game.currentSquare, actual);
        }

        [TestMethod]
        public void CheckForCenterPlay()
        {
            Game game = new Game();
            var s = new List<string>() { "", "", "", "", "", "X", "", "", "" };
            game.squaresPlayed = s;
            game.letterOfCurrentPlayerSide = "O";
            game.turnNumber = 1;
            game.getAiMove();

            var actual = 4;

            Assert.AreEqual(game.currentSquare, actual);
        }

        [TestMethod]
        public void CheckForWinngingMoveTest()
        {
            Game game = new Game();
            var s = new List<string>() { "O", "", "X", "", "O", "X", "", "", "" };
            game.squaresPlayed = s;
            game.letterOfCurrentPlayerSide = "O";
            game.turnNumber = 4;
            game.getAiMove();

            var actual = 8;

            Assert.AreEqual(game.currentSquare, actual);
        }

        [TestMethod]
        public void CheckForBlockingMoveTest()
        {
            Game game = new Game();
            var s = new List<string>() { "O", "", "X", "", "O", "X", "", "", "" };
            game.squaresPlayed = s;
            game.letterOfCurrentPlayerSide = "X";
            game.turnNumber = 4;
            game.getAiMove();

            var actual = 8;

            Assert.AreEqual(game.currentSquare, actual);
        }

        [TestMethod]
        public void AttemptToPlayOccupiedSquareTest()
        {
            Game game = new Game();
            var s = new List<string>() { "O", "", "X", "", "O", "X", "", "", "" };
            game.squaresPlayed = s;
            game.letterOfCurrentPlayerSide = "X";
            game.turnNumber = 4;
            game.currentSquare = 0;
            game.squareSelectionAttempt();

            var actual = "O";

            Assert.AreEqual(game.squaresPlayed[0], actual);
        }
    }
}
