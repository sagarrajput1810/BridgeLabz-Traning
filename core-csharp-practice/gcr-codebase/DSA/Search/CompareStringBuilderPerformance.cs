using System.Diagnostics;
using System.Text;

namespace SearchProblems
{
    public static class CompareStringBuilderPerformanceProblem
    {
        public static (long builderMilliseconds, long plusMilliseconds, string result) Compare(string seed, int repeats)
        {
            seed ??= string.Empty;
            repeats = System.Math.Max(0, repeats);

            var sw = Stopwatch.StartNew();
            var sb = new StringBuilder(seed.Length * repeats);
            for (int i = 0; i < repeats; i++)
            {
                sb.Append(seed);
            }
            string builderResult = sb.ToString();
            sw.Stop();
            long builderMs = sw.ElapsedMilliseconds;

            sw.Restart();
            string concatResult = string.Empty;
            for (int i = 0; i < repeats; i++)
            {
                concatResult += seed;
            }
            sw.Stop();
            long plusMs = sw.ElapsedMilliseconds;

            return (builderMs, plusMs, builderResult);
        }
    }
}
