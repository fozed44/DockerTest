using System;

namespace Front
{
    public class TestResult
    {
        public DateTime Date { get; set; }

        public double   GetSomethingResult  { get; set; }
        public TimeSpan GetSomethingRunTime { get; set; }
        public double   GetSomeOtherThingResult  { get; set; }
        public TimeSpan GetSomeOtherThingRunTime { get; set; }
    }
}
