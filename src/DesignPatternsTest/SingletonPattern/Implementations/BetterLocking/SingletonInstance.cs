using Microsoft.Extensions.Logging;
using SingletonPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tools.Logging;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsTest.SingletonPattern.Implementations.BetterLocking
{
    public class SingletonInstance
    {
        private readonly ITestOutputHelper _output;
        public SingletonInstance(ITestOutputHelper output)
        {
            _output = output;
            SingletonTestHelpers.Reset(typeof(SingletonBetterLocking));
            Logger.Clear();
        }

        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<SingletonBetterLocking>());

            var result = SingletonBetterLocking.Instance;

            Assert.NotNull(result);
            Assert.IsType<SingletonBetterLocking>(result);

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }

        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<SingletonBetterLocking>());

            // configure logger to slow down the creation longer than the pauses below
            Logger.DelayMilliseconds = 10;

            var result1 = SingletonBetterLocking.Instance;
            Thread.Sleep(1);
            var result2 = SingletonBetterLocking.Instance;
            Thread.Sleep(1);
            var result3 = SingletonBetterLocking.Instance;

            var log = Logger.Output();
            Assert.Equal(1, log.Count(log => log.Contains("Constructor")));
            Assert.Equal(3, log.Count(log => log.Contains("Instance")));

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }

        [Fact]
        public void CallsConstructorMultipleTimesGivenThreeParallelInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<SingletonBetterLocking>());

            // configure logger to slow down the creation long enough to cause problems
            Logger.DelayMilliseconds = 50;

            var strings = new List<string>() { "one", "two", "three" };
            var instances = new List<SingletonBetterLocking>();
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
            Parallel.ForEach(strings, options, instance =>
            {
                instances.Add(SingletonBetterLocking.Instance);
            });

            var log = Logger.Output();
            try
            {
                Assert.Equal(1, log.Count(log => log.Contains("Constructor")));
                Assert.Equal(3, log.Count(log => log.Contains("Instance")));
            }
            finally
            {
                Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
            }
        }

    }
}
