namespace SimpleNetBenchmark.Measurers
{
    public class StopwatchBenchmarkMeasurer : IBenchmarkMeasurer
    {
        public void Start()
        {
        }

        public void Stop()
        {
        }

        public long ElapsedTicks 
        {
            get
            {
                return 0;
            }
        }

        public double ElapsedMilliseconds
        {
            get
            {
                return 0;
            }
        }
    }
}