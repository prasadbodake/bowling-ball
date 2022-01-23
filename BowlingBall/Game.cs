using BowlingBall.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBall
{
    public class Game : IGame
    {
        private readonly List<Frame> frames = new List<Frame>();

        public static IGame StartNew()
        {
            return new Game();
        }

        public void Roll(int pins)
        {
            if (frames.Count == Constants.MaxFramesLimit && frames.Last().IsClosed)
            {
                throw new MaxFramesExceedException($"Frame count exceed the max limit of {Constants.MaxFramesLimit}.");
            }

            if (!frames.Any() || frames.Last().IsClosed)
            {
                var isLastFrame = frames.Count == Constants.MaxFramesLimit - 1;
                frames.Add(new Frame(Constants.StartingPinCount, isLastFrame));
            }

            frames.Last().RegisterRoll(pins);
        }

        public int GetScore()
        {
            int score = 0;
            for (var frameIndex = 0; frameIndex < frames.Count; frameIndex++)
            {
                var frame = frames[frameIndex];
                var frameScore = 0;
                var bonusScore = 0;
                var isStrike = false;

                var maxRollIndex = frame.RollResults.Count < 2 ? frame.RollResults.Count : 2;

                for (var rollIndex = 0; rollIndex < maxRollIndex; rollIndex++)
                {
                    var result = frame.RollResults[rollIndex];
                    frameScore += result;

                    // calculate bonus score for a strike
                    if (result == Constants.StartingPinCount)
                    {
                        isStrike = true;

                        // look 2 rolls ahead
                        bonusScore += CalculateBonusScore(frameIndex, rollIndex, 2);
                        break;
                    }
                }

                // calculate bonus score for a spare
                if (!isStrike && frameScore == Constants.StartingPinCount)
                {
                    // look 1 roll ahead
                    bonusScore += CalculateBonusScore(frameIndex, maxRollIndex - 1, 1);
                }

                score += frameScore + bonusScore;
            }

            return score;
        }
        private int CalculateBonusScore(int frameIndex, int rollIndex, int rollCount)
        {
            if (rollCount == 0)
            {
                return 0;
            }

            if (frames[frameIndex].RollResults.Count > rollIndex + 1)
            {
                return frames[frameIndex].RollResults[rollIndex + 1] + CalculateBonusScore(frameIndex, rollIndex + 1, rollCount - 1);

            }
            else if (frames.Count > frameIndex + 1)
            {
                return frames[frameIndex + 1].RollResults[0] + CalculateBonusScore(frameIndex + 1, 0, rollCount - 1);
            }
            return 0;
        }
    }
}
