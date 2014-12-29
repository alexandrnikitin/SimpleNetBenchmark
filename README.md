SimpleNetBenchmark
================

Simple .NET Benchmark provides simple api to benchmark your code.

Install
-------
It's available via [nuget package](https://www.nuget.org/packages/SimpleNetBenchmark/)  
PM> `Install-Package SimpleNetBenchmark`

Example Usage
-------------

Simple:

	static void Main(string[] args)
    {
		Please.Run(x =>
		{
			x.Benchmark.For(() =>
			{
				int sum = 0;
				for (int i = 0; i < _list.Count; i++)
					sum += _list[i];

				var result = sum;
			})
			.WithName("For")
			.WithIterationInit(() => _list = Enumerable.Range(0, 5000000).ToList());

			x.Benchmark.For(() =>
			{
				int length = _list.Count;
				int sum = 0;
				for (int i = 0; i < length; i++)
					sum += _list[i];
			})
			.WithName("For optimized")
			.WithIterationInit(() => _list = Enumerable.Range(0, 5000000).ToList());
		});
    }
	
Customizable:

	static void Main(string[] args)
	{
		new BenchmarkHostBuilder()
			.Configure(x =>
			{
				x.WriteResultsTo(new ConsoleBenchmarkResultWriter());
				x.WithMeasurer(new StopwatchBenchmarkMeasurer());

				x.AddConfigurator(new ThreadSetupBenchmarkHostConfigurator());
				x.AddConfigurator(new MemoryCollectingBenchmarkHostConfigurator());
				x.AddConfigurator(new GCSetupBenchmarkHostConfigurator());
			})
			.Compose(x =>
			{
				x.Benchmark.For(() =>
				{
					int sum = 0;
					for (int i = 0; i < _list.Count; i++)
						sum += _list[i];

					var result = sum;
				})
				.WithName("For")
				.WithIterationInit(() => _list = Enumerable.Range(0, 5000000).ToList())
				.WithWarmupIterationCount(20)
				.WithIterationCount(20);
			})
			.Run();
	}
