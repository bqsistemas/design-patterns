using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace TestingCode
{
    [Trait("Category", "PlayerCharacter")]
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter _playerCharacter;
        private readonly ITestOutputHelper _output;
        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;

            _output.WriteLine("Creating new PlayerCharacter");
            _playerCharacter = new PlayerCharacter();
        }

        [Fact]
        public void BeInexperienceWhenNew()
        {
            Assert.True(_playerCharacter.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            _playerCharacter.FirstName = "Sarah";
            _playerCharacter.LastName = "Smith";

            Assert.Equal("Sarah Smith", _playerCharacter.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {
            _playerCharacter.FirstName = "Sarah";
            _playerCharacter.LastName = "Smith";

            Assert.StartsWith("Sarah", _playerCharacter.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            _playerCharacter.FirstName = "Sarah";
            _playerCharacter.LastName = "Smith";

            Assert.EndsWith("Smith", _playerCharacter.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            _playerCharacter.FirstName = "SARAH";
            _playerCharacter.LastName = "SMITH";

            Assert.Equal("Sarah Smith", _playerCharacter.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            _playerCharacter.FirstName = "Sarah";
            _playerCharacter.LastName = "Smith";

            Assert.Contains("ah Sm", _playerCharacter.FullName);
        }

        [Fact]
        public void CalculateFullNameFullNameWithTitleCase()
        {
            _playerCharacter.FirstName = "Sarah";
            _playerCharacter.LastName = "Smith";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]", _playerCharacter.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            Assert.Equal(100, _playerCharacter.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            Assert.NotEqual(0, _playerCharacter.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            _playerCharacter.Sleep(); // Expect increase between 1 to 100 inclusive;

            // Assert.True(_playerCharacter.Health >= 101 && _playerCharacter.Health <= 200);
            Assert.InRange(_playerCharacter.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            Assert.Null(_playerCharacter.NickName);
        }

        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", _playerCharacter.Weapons);
        }

        [Fact]
        public void NoHaveAStaffOfWonder()
        {
            Assert.DoesNotContain("Staff Of Wonder", _playerCharacter.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.Contains(_playerCharacter.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, _playerCharacter.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefultWeapons()
        {
            Assert.All(_playerCharacter.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaiseSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => _playerCharacter.PlayerSlept += handler,
                handler => _playerCharacter.PlayerSlept -= handler, 
                () => _playerCharacter.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            Assert.PropertyChanged(_playerCharacter, "Health", () => _playerCharacter.TakeDamage(10));
        }

        [Theory]
        [InlineData(0, 100)]
        [InlineData(50, 50)]
        [InlineData(40, 60)]
        [InlineData(101, 1)]
        public void TakeDamage(int damage, int expectedHealth)
        {
            _output.WriteLine($"Take damage: {damage} - expected health: {expectedHealth}");
            _playerCharacter.TakeDamage(damage);

            Assert.Equal(expectedHealth, _playerCharacter.Health);
        }

        public void Dispose()
        {
            _output.WriteLine($"Dispose PlayerCharacter {_playerCharacter.FullName}");
            // _playerCharacter.Dispose();
        }

    }
}
