using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace SimpleNetBenchmark.Measurers
{
    public class QueryPerformanceCounterMeasurer : IBenchmarkMeasurer
    {
        public QueryPerformanceCounterMeasurer()
        {
            if (QueryPerformanceFrequency(out freq) == false)
            {
                // high-performance counter not supported
                throw new Win32Exception();
            }

        }
        private long freq;
        private long startTime, stopTime;

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);


        public void Start()
        {
            // lets do the waiting threads there work
            Thread.Sleep(0);

            QueryPerformanceCounter(out startTime);

        }

        public void Stop()
        {
            QueryPerformanceCounter(out stopTime);
        }

        public long ElapsedTicks
        {
            get
            {
                return stopTime - startTime;
            }
        }

        public double ElapsedMilliseconds
        {
            get
            {
                return (((double)(stopTime - startTime)) * 1000) / (double)freq;
            }
        }
    }
}