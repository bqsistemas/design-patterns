using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace TestingCode
{
    [Trait("Category", "Enemy")]
    public class BossEnemyShould
    {
        private readonly ITestOutputHelper _output;

        public BossEnemyShould(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void HaveCorrectPower()
        {
            _output.WriteLine("Creating Boss Enemy");
            BossEnemy bossEnemy = new BossEnemy();

            Assert.Equal(166.667, bossEnemy.SpecialAttackPower, 3);
        }
    }
}
