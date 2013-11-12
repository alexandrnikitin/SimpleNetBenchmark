using System;
using System.Diagnostics;
using System.Threading;

namespace SimpleNetBenchmark.Configurators
{
    public class ThreadBenchmarkHostConfigurator : IBenchmarkHostConfigurator
    {
        public void Init()
        {
            long seed = Environment.TickCount;
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High; //realtime?
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
        }

        public void Deinit()
        {
            //todo
        }
    }
}