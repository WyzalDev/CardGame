using System;

namespace _Project.Core.Enemies
{
    public class SimpleEnemyGenerator : IEnemyGenerator
    {
        private readonly Enemy _enemyExample;

        public SimpleEnemyGenerator(Enemy enemyExample)
        {
            _enemyExample = enemyExample;
        }

        public Enemy GenerateEnemy()
        {
            var enemy = new Enemy(_enemyExample.Name, _enemyExample.Sprite, _enemyExample.MaxHealth);
            return enemy;
        }
    }
}