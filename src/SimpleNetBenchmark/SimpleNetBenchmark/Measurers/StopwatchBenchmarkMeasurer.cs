using System.Diagnostics;

namespace SimpleNetBenchmark.Measurers
{
    public class StopwatchBenchmarkMeasurer : IBenchmarkMeasurer
    {
        private readonly Stopwatch _stopwatch = new Stopwatch();

        public void Start()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
        }

        public void Stop()
        {
            _stopwatch.Stop();
        }

        public long ElapsedTicks 
        {
            get
            {
                return _stopwatch.Elapsed.Ticks;
            }
        }

        public double ElapsedMilliseconds
        {
            get
            {
                return _stopwatch.Elapsed.Milliseconds;
            }
        }
    }
}