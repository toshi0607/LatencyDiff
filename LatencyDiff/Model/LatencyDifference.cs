using System;

namespace LatencyDiff.Model
{
    public class LatencyDifference
    {
        public long TimeA { get; set; }
        public long TimeB { get; set; }
        public Double Diff { get; set; }

        public LatencyDifference(long timeA, long timeB)
        {
            TimeA = timeA;
            TimeB = timeB;
            Diff = Math.Abs(timeA - timeB);
        }
    }
}
