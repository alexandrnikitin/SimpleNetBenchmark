using System;
using System.Diagnostics;
using System.Threading;

namespace SimpleNetBenchmark.Configurators
{
    public class ThreadSetupBenchmarkHostConfigurator : IBenchmarkHostConfigurator
    {
        private IntPtr _processorAffinityOriginal;
        private ProcessPriorityClass _priorityClassOriginal;
        private ThreadPriority _priorityOriginal;

        public void Init()
        {
            _processorAffinityOriginal = Process.GetCurrentProcess().ProcessorAffinity;
            _priorityClassOriginal = Process.GetCurrentProcess().PriorityClass;
            _priorityOriginal = Thread.CurrentThread.Priority;
            
            long seed = Environment.TickCount;
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
        }

        public void Deinit()
        {
            Process.GetCurrentProcess().ProcessorAffinity = _processorAffinityOriginal;
            Process.GetCurrentProcess().PriorityClass = _priorityClassOriginal;
            Thread.CurrentThread.Priority = _priorityOriginal;
        }
    }
}