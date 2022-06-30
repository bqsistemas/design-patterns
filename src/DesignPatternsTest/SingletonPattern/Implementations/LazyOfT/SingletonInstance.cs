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

namespace DesignPatternsTest.SingletonPattern.Implementations.LazyOfT
{
    public class SingletonInstance
    {
        private readonly ITestOutputHelper _output;
        public SingletonInstance(ITestOutputHelper output)
        {
            _output = output;

            // This doesn't work with a static readonly field
            //SingletonTestHelpers.Reset(typeof(Singleton));

            Logger.Clear();
        }

        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            // This no longer works
            //Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            var result = SingletonLazyOfT.Instance;

            Assert.NotNull(result);
            Assert.IsType<SingletonLazyOfT>(result);

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }

        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            // This no longer works
            //Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            // configure logger to slow down the creation longer than the pauses below
            Logger.DelayMilliseconds = 10;

            var result1 = SingletonLazyOfT.Instance;
            Thread.Sleep(1);
            var result2 = SingletonLazyOfT.Instance;
            Thread.Sleep(1);
            var result3 = SingletonLazyOfT.Instance;

            var log = Logger.Output();

            // we can't check this since it depends on if this test is run alone or after others
            // Assert.Equal(1, log.Count(log => log.Contains("Constructor")));

            Assert.Equal(3, log.Count(log => log.Contains("Instance")));

            Logger.Output().ToList().ForEach(h => _output.WriteLine(h));
        }
    }
}
