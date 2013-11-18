using System.Runtime;

namespace SimpleNetBenchmark.Configurators
{
    public class GCBenchmarkHostConfigurator : IBenchmarkHostConfigurator
    {
        public void Init()
        {
            GCSettings.LatencyMode = GCLatencyMode.LowLatency;
        }

        public void Deinit()
        {
            //todo
        }
    }
}