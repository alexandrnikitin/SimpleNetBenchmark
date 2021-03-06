﻿using System;

namespace SimpleNetBenchmark
{
    public class BenchmarkHostBuilder
    {
        private readonly IBenchmarkHost _benchmarkHost;

        public BenchmarkHostBuilder()
        {
            _benchmarkHost = new BenchmarkHost();
        }

        public IBenchmarkHostRunner Compose(Action<IBenchmarkComposer> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            action(new BenchmarkComposer(_benchmarkHost));

            return new BenchmarkHostRunner(_benchmarkHost);
        }

        public BenchmarkHostBuilder Configure(Action<IBenchmarkHostConfigurer> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            var benchmarkHostConfigurer = new BenchmarkHostConfigurer(_benchmarkHost);
            action(benchmarkHostConfigurer);

            return this;
        }
    }
}