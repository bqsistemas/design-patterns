using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingCode.Cross;
using Xunit;
using Xunit.Abstractions;

namespace TestingCode
{
    [Collection("GameState collection")]
    [Trait("Category", "GameStateCross")]
    public class TestCrossContext2
    {
        private readonly GameStateFixture _fixture;
        private readonly ITestOutputHelper _output;

        public TestCrossContext2(GameStateFixture fixture, ITestOutputHelper output)
        {
            _output = output;
            _fixture = fixture;
        }

        [Fact]
        public void Test3()
        {
            _output.WriteLine($"GameState ID={ _fixture.State.Id }");
        }

        [Fact]
        public void Test4()
        {
            _output.WriteLine($"GameState ID={ _fixture.State.Id }");
        }
    }
}
