using System.Collections.Generic;
using SimpleNetBenchmark.Configurators;
using SimpleNetBenchmark.Measurers;

namespace SimpleNetBenchmark
{
    public class BenchmarkHost : IBenchmarkHost
    {
        private readonly List<IBenchmarkHostConfigurator> _configurators;
        private readonly List<IBenchmark> _benchmarks;

        public BenchmarkHost(List<IBenchmarkHostConfigurator> configurators, IBenchmarkMeasurer measurer, IBenchmarkResultWriter resultWriter)
        {
            _configurators = configurators;
            Measurer = measurer;
            ResultWriter = resultWriter;

            _benchmarks = new List<IBenchmark>();
            _configurators = new List<IBenchmarkHostConfigurator>();
        }

        public BenchmarkHost()
            : this(
                new List<IBenchmarkHostConfigurator>
                {
                    //new ThreadSetupBenchmarkHostConfigurator(),
                    //new GCSetupBenchmarkHostConfigurator(),
                    //new MemoryCollectingBenchmarkHostConfigurator()
                },
                new StopwatchBenchmarkMeasurer(),
                new ConsoleBenchmarkResultWriter())
        {
        }

        public List<IBenchmarkHostConfigurator> Configurators
        {
            get
            {
                return _configurators;
            }
        }

        public List<IBenchmark> Benchmarks
        {
            get
            {
                return _benchmarks;
            }
        }

        public IBenchmarkResultWriter ResultWriter { get; set; }
        public IBenchmarkMeasurer Measurer { get; set; }

        public bool Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}