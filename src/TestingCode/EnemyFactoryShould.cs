using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestingCode
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory enemyFactory = new EnemyFactory();

            Enemy enemy = enemyFactory.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact(Skip = "Need changes")]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            EnemyFactory enemyFactory = new EnemyFactory();

            Enemy enemy = enemyFactory.Create("Zombie");

            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            EnemyFactory enemyFactory = new EnemyFactory();

            Enemy enemy = enemyFactory.Create("Zombie King", true);

            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            EnemyFactory enemyFactory = new EnemyFactory();

            Enemy enemy = enemyFactory.Create("Zombie King", true);

            // Assert.IsType<Enemy>(enemy);
            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateSeparateInstances()
        {
            EnemyFactory enemyFactory = new EnemyFactory();

            Enemy enemy1 = enemyFactory.Create("Zombie");
            Enemy enemy2 = enemyFactory.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
        }

        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory enemyFactory = new EnemyFactory();

            Assert.Throws<ArgumentNullException>(() => enemyFactory.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyFactory enemyFactory = new EnemyFactory();

            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => enemyFactory.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }
    }
}
