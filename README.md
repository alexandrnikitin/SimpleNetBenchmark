SimpleNetBenchmark
================

Simple .NET Benchmark provides simple api to benchmark your code.

Example Usage
-------------

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
