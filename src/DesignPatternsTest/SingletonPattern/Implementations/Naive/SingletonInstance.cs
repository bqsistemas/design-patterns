using Microsoft.Extensions.Logging;
using SingletonPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Logging;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsTest.SingletonPattern.Implementations.Naive
{
    public class SingletonInstance
    {
        private readonly ITestOutputHelper _output;


        public SingletonInstance(ITestOutputHelper output)
        {
            _output = output;
            SingletonTestHelpers.Reset(typeof(SingletonNaive));
            Logger.Clear();
        }

        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<SingletonNaive>());

            var result = SingletonNaive.Instance;

            Assert.NotNull(result);
            Assert.IsType<SingletonNaive>(result);

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }

        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<SingletonNaive>());

            var one = SingletonNaive.Instance;
            var two = SingletonNaive.Instance;
            var three = SingletonNaive.Instance;

            var log = Logger.Output();
            Assert.Equal(1, log.Count(log => log.Contains("Constructor")));
            Assert.Equal(3, log.Count(log => log.Contains("Instance")));

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }

        [Fact]
        public void CallsConstructorMultipleTimesGivenThreeParallelInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<SingletonNaive>());

            // configure logger to slow down the creation long enough to cause problems
            Logger.DelayMilliseconds = 50;

            var strings = new List<string>() { "one", "two", "three" };
            var instances = new List<SingletonNaive>();
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
            Parallel.ForEach(strings, options, instance =>
            {
                instances.Add(SingletonNaive.Instance);
            });

            var log = Logger.Output();
            try
            {
                Assert.True(log.Count(log => log.Contains("Constructor")) > 1);
                Assert.Equal(3, log.Count(log => log.Contains("Instance")));
            }
            finally
            {
                Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
            }
        }
    }
}
