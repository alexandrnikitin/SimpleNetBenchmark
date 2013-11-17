using System.Collections.Generic;

namespace SimpleNetBenchmark
{
    public class BenchmarkHost : IBenchmarkHost
    {
        private IBenchmarkHostRunner _runner;
        private List<IBenchmarkHostConfigurator> _configurators;
        private IEnumerable<IBenchmark> _benchmarks;

        public IBenchmarkHostRunner Runner {
            get
            {
                return _runner;
            }
        }

        public IEnumerable<IBenchmarkHostConfigurator> Configurators
        {
            get
            {
                return _configurators;
            }
        }

        public IEnumerable<IBenchmark> Benchmarks
        {
            get
            {
                return _benchmarks;
            }
        }

        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}