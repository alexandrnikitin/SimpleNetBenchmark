﻿using System.Collections.Generic;

namespace SimpleNetBenchmark
{
    public interface IBenchmarkResult
    {
        List<IBenchmarkIterationResult> BenchmarkIterationResults { get; set; }
        List<IBenchmarkIterationResult> WarmupIterationResults { get; set; }
    }
}