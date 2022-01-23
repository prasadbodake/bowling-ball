using System.Collections.Generic;

namespace BowlingBall
{
    internal class Frame
    {
        private int standingPins;
        private readonly int startingPinCount;
        private readonly bool isLastFrame;
        private readonly IList<int> rollResults = new List<int>();


        public IReadOnlyList<int> RollResults { get { return (IReadOnlyList<int>) rollResults; } }


        public bool IsClosed => isLastFrame ?
                                rollResults.Count == 3 :
                                standingPins == 0 || rollResults.Count == 2;

        public Frame(int startingPinCount, bool isLastFrame = false)
        {
            this.startingPinCount = startingPinCount;
            standingPins = startingPinCount;
            this.isLastFrame = isLastFrame;
        }


        public void RegisterRoll(int pins)
        {
            rollResults.Add(pins);
            standingPins -= pins;
            if (isLastFrame && standingPins == 0)
            {
                standingPins = startingPinCount;
            }
        }
    }
}
