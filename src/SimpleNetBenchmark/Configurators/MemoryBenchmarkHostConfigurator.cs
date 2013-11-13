using System;

namespace SimpleNetBenchmark.Configurators
{
    public class MemoryBenchmarkHostConfigurator : IBenchmarkHostConfigurator
    {
        public void Init()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public void Deinit()
        {
            //todo
        }
    }
}