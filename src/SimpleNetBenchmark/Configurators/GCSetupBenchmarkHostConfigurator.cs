using System.Runtime;

namespace SimpleNetBenchmark.Configurators
{
    public class GCSetupBenchmarkHostConfigurator : IBenchmarkHostConfigurator
    {
        private GCLatencyMode _gcLatencyModeOriginal;

        public void Init()
        {
            _gcLatencyModeOriginal = GCSettings.LatencyMode;
            GCSettings.LatencyMode = GCLatencyMode.LowLatency;
        }

        public void Deinit()
        {
            GCSettings.LatencyMode = _gcLatencyModeOriginal;
        }
    }
}