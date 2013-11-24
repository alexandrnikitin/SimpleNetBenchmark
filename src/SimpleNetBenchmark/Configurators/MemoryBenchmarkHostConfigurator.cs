using System;

namespace SimpleNetBenchmark.Configurators
{
    public class MemoryCollectingBenchmarkHostConfigurator : IBenchmarkHostConfigurator
    {
        public void Init()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public void Deinit()
        {
        }
    }
}