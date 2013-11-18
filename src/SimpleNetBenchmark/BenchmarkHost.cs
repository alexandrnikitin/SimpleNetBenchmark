using System.Collections.Generic;

namespace SimpleNetBenchmark
{
    public class BenchmarkHost : IBenchmarkHost
    {
        private IBenchmarkHostRunner _runner;
        private List<IBenchmarkHostConfigurator> _configurators;
        private List<IBenchmark> _benchmarks;


        public BenchmarkHost(IBenchmarkHostRunner runner, List<IBenchmarkHostConfigurator> configurators, IBenchmarkMeasurer measurer, IBenchmarkResultWriter resultWriter)
        {
            _runner = runner;
            _configurators = configurators;
            Measurer = measurer;
            ResultWriter = resultWriter;

            _benchmarks = new List<IBenchmark>();
            _configurators = new List<IBenchmarkHostConfigurator>();
        }

        public IBenchmarkHostRunner Runner
        {
            get
            {
                return _runner;
            }
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

        public void Run()
        {
            _runner.Run(this);
        }
    }
}