using System;

namespace BowlingBall.Exceptions
{
    public class MaxFramesExceedException : InvalidOperationException
    {
        public MaxFramesExceedException(string msg = "") : base(msg)
        {

        }
    }
}
