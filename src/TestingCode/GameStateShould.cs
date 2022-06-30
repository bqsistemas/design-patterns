using Business.Models;
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
    [Trait("Category", "GameState")]
    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _fixture;
        private readonly ITestOutputHelper _output;

        public GameStateShould(GameStateFixture fixture, ITestOutputHelper output)
        {
            _output = output;
            _fixture = fixture;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            _output.WriteLine($"GameState ID={ _fixture.State.Id }");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _fixture.State.Players.Add(player1);
            _fixture.State.Players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

            _fixture.State.Earthquake();

            Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Health);
        }

        [Fact]
        public void Reset()
        {
            _output.WriteLine($"GameState ID={ _fixture.State.Id }");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _fixture.State.Players.Add(player1);
            _fixture.State.Players.Add(player2);

            _fixture.State.Reset();

            Assert.Empty(_fixture.State.Players);
        }
    }
}
