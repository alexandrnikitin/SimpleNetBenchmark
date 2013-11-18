using System;

namespace SimpleNetBenchmark
{
    public class ConsoleBenchmarkResultWriter : IBenchmarkResultWriter
    {
        public void Write(IBenchmark benchmark, IBenchmarkResult result)
        {
            Console.WriteLine("Benchmark: {0}", benchmark.Name);
            Console.WriteLine("Warmup:");
            foreach (var iterationResult in result.WarmupIterationResults)
            {
                Console.WriteLine(iterationResult);
            }

            Console.WriteLine("Results:");
            foreach (var iterationResult in result.BenchmarkIterationResults)
            {
                Console.WriteLine(iterationResult);
            }

            Console.WriteLine("Summary:");
            Console.WriteLine(result);
        }
    }
}