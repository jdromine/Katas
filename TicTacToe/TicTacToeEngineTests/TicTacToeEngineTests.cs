using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeEngine;

namespace Tests
{
    [TestClass]
    public class TicTacToeEngineTests
    {
        public Game CreateGame()
        {
            Player one = new Player("Josh");
            Player two = new Player("Kayla");

            return new Game(one, two);
        }

        [TestMethod]
        public void should_create_3_by_3_matrix()
        {
            Game ticTacToe = CreateGame();
            ticTacToe.ResetGame();

            int blankSpaceCount = 0;

            foreach (Space s in ticTacToe.Board)
            {
                if (s.SpaceHolder == null)
                {
                    blankSpaceCount++;
                }
            }

            Assert.AreEqual(9, blankSpaceCount);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void should_raise_error_when_player_tries_to_occupy_held_space()
        {
            Game ticTacToe = CreateGame();
            ticTacToe.ResetGame();

            ticTacToe.Play(1);
            ticTacToe.Play(1);

        }

        [TestMethod]
        public void should_change_turns_after_playing()
        {
            Game ticTacToe = CreateGame();
            ticTacToe.ResetGame();

            Player ActivePlayer = ticTacToe.ActivePlayer;

            ticTacToe.Play(0);

            Assert.AreNotEqual(ActivePlayer, ticTacToe.ActivePlayer);
        }

        [TestMethod]
        public void should_create_x_winner_when_X_diagonals()
        {
            Game ticTacToe = CreateGame();
            ticTacToe.ResetGame();

            //Player X goes first
            ticTacToe.Play(0);
            ticTacToe.Play(1);
            ticTacToe.Play(4);
            ticTacToe.Play(5);
            ticTacToe.Play(8);

            Assert.AreEqual((int)GameState.PlayerXWins, ticTacToe.State);
        }
    }
}
