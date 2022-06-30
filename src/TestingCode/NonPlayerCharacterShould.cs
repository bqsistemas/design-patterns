using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingCode.Attributes;
using TestingCode.Data;
using Xunit;
using Xunit.Abstractions;

namespace TestingCode
{
    [Trait("Category", "NonPlayerCharacter")]
    public class NonPlayerCharacterShould
    {
        private readonly ITestOutputHelper _output;
        public NonPlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;
        }
        // [Theory]
        // [MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        // public void TakeDamage(int damage, int expectedHealth)
        // {
        //     _output.WriteLine($"Take damage: {damage} - expected health: {expectedHealth}");
        // 
        //     NonPlayerCharacter nonPlayerCharacter = new NonPlayerCharacter();
        // 
        //     nonPlayerCharacter.TakeDamage(damage);
        // 
        //     Assert.Equal(expectedHealth, nonPlayerCharacter.Health);
        // }

        // [Theory]
        // [MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
        // public void TakeDamage(int damage, int expectedHealth)
        // {
        //     _output.WriteLine($"Take damage: {damage} - expected health: {expectedHealth}");
        //     NonPlayerCharacter sut = new NonPlayerCharacter();
        // 
        //     sut.TakeDamage(damage);
        // 
        //     Assert.Equal(expectedHealth, sut.Health);
        // }

        [Theory]
        [HealthDamageData]
        public void TakeDamage(int damage, int expectedHealth)
        {
            _output.WriteLine($"Take damage: {damage} - expected health: {expectedHealth}");
            NonPlayerCharacter sut = new NonPlayerCharacter();

            sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, sut.Health);
        }
    }
}
