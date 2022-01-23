using BowlingBall.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {

        [TestMethod]
        public void Frames_with_combination_of_strikes_and_spare_should_have_correct_score()
        {
            IGame game = StartNewGame();

            game.Roll(10);

            game.Roll(9);
            game.Roll(1);

            game.Roll(5);
            game.Roll(5);

            game.Roll(7);
            game.Roll(2);

            game.Roll(10);

            game.Roll(10);

            game.Roll(10);

            game.Roll(9);
            game.Roll(0);

            game.Roll(8);
            game.Roll(2);

            game.Roll(9);
            game.Roll(1);
            game.Roll(10);

            Assert.AreEqual(game.GetScore(), 187, "Total score does not match!");

            var ex = Assert.ThrowsException<MaxFramesExceedException>(() => game.Roll(10));
            Assert.AreEqual(ex.Message, $"Frame count exceed the max limit of {Constants.MaxFramesLimit}.");
        }

        private static IGame StartNewGame()
        {
            return Game.StartNew();
        }

        [TestMethod]
        public void All_frames_with_strikes_should_have_score_a_max_possible_score_300()
        {
            IGame game = StartNewGame();
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);
            game.Roll(10);

            Assert.AreEqual(game.GetScore(), Constants.MaxPossibleScore, "Total score does not match!");

            var ex = Assert.ThrowsException<MaxFramesExceedException>(() => game.Roll(0));
            Assert.AreEqual(ex.Message, $"Frame count exceed the max limit of {Constants.MaxFramesLimit}.");
        }


        [TestMethod]
        public void Frames_with_all_spare_and_last_strike_should_have_correct_score()
        {
            IGame game = StartNewGame();

            game.Roll(1);
            game.Roll(9);

            game.Roll(2);
            game.Roll(8);

            game.Roll(3);
            game.Roll(7);

            game.Roll(4);
            game.Roll(6);

            game.Roll(5);
            game.Roll(5);

            game.Roll(6);
            game.Roll(4);

            game.Roll(7);
            game.Roll(3);

            game.Roll(8);
            game.Roll(2);

            game.Roll(9);
            game.Roll(1);

            game.Roll(1);
            game.Roll(9);

            game.Roll(10);

            Assert.AreEqual(game.GetScore(), 155, "Total score does not match!");

            var ex = Assert.ThrowsException<MaxFramesExceedException>(() => game.Roll(0));
            Assert.AreEqual(ex.Message, $"Frame count exceed the max limit of {Constants.MaxFramesLimit}.");
        }


        [TestMethod]
        public void All_frames_with_spares_should_have_correct_score()
        {
            IGame game = StartNewGame();

            game.Roll(1);
            game.Roll(9);

            game.Roll(2);
            game.Roll(8);

            game.Roll(3);
            game.Roll(7);

            game.Roll(4);
            game.Roll(6);

            game.Roll(5);
            game.Roll(5);

            game.Roll(6);
            game.Roll(4);

            game.Roll(7);
            game.Roll(3);

            game.Roll(8);
            game.Roll(2);

            game.Roll(9);
            game.Roll(1);

            game.Roll(1);
            game.Roll(9);

            game.Roll(2);

            Assert.AreEqual(game.GetScore(), 147, "Total score does not match!");

            var ex = Assert.ThrowsException<MaxFramesExceedException>(() => game.Roll(0));
            Assert.AreEqual(ex.Message, $"Frame count exceed the max limit of {Constants.MaxFramesLimit}.");
        }


        [TestMethod]
        public void Game_with_no_frames_should_have_zero_score()
        {
            IGame game = StartNewGame();
            Assert.AreEqual(game.GetScore(), 0, "Total score does not match!");
        }


        [TestMethod]
        public void All_frames_with_all_pins_standing_should_have_zero_score()
        {
            IGame game = StartNewGame();
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);
            game.Roll(0);

            Assert.AreEqual(game.GetScore(), 0, "Total score does not match!");

            var ex = Assert.ThrowsException<MaxFramesExceedException>(() => game.Roll(0));
            Assert.AreEqual(ex.Message, $"Frame count exceed the max limit of {Constants.MaxFramesLimit}.");
        }
    }
}
