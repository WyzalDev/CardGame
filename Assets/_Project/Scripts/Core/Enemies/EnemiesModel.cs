using System;
using UnityEngine;

namespace _Project.Core.Enemies
{
    public class EnemiesModel : IDisposable
    {
        public Action<int, Enemy> OnSlotEnemyDeath { get; set; }

        public Action OnEnemiesReset { get; set; }

        private readonly IEnemyGenerator _enemyGenerator;
        
        private Enemy[] _enemies;
        
        public Enemy[] Enemies => _enemies;

        public EnemiesModel(IEnemyGenerator enemyGenerator, int enemiesCount)
        {
            _enemyGenerator = enemyGenerator;
            _enemies = new Enemy[enemiesCount];
        }

        public void DealDamage(int damage, int slotIndex)
        {
            if (slotIndex >= _enemies.Length)
            {
                Debug.LogError($"Enemies {_enemies.Length} are out of range");
                return;
            }

            _enemies[slotIndex].DealDamage(damage);
        }

        public void ResetEnemies()
        {
            for (var i = 0; i < _enemies.Length; i++)
            {
                if (_enemies[i] != null)
                    UnSubscribeEnemy(_enemies[i]);

                _enemies[i] = _enemyGenerator.GenerateEnemy();
                SubscribeEnemy(_enemies[i]);
            }

            OnEnemiesReset?.Invoke();
        }

        private void UnSubscribeEnemy(Enemy enemy)
        {
            enemy.OnDeath -= OnEnemySlotDeath;
        }

        private void SubscribeEnemy(Enemy enemy)
        {
            enemy.OnDeath += OnEnemySlotDeath;
        }

        private void OnEnemySlotDeath()
        {
            var deadEnemyIndex = FindDeadEnemyIndex(out var deadEnemy);
            OnSlotEnemyDeath?.Invoke(deadEnemyIndex, deadEnemy);
            _enemies[deadEnemyIndex] = null;
        }

        private int FindDeadEnemyIndex(out Enemy enemy)
        {
            for (var i = 0; i < _enemies.Length; i++)
            {
                if (_enemies[i] == null)
                    continue;

                if (_enemies[i].Health > 0)
                    continue;

                enemy = _enemies[i];
                return i;
            }

            Debug.LogError("Death Event Invokes, but no dead enemies");
            enemy = null;
            return 0;
        }

        public void Dispose()
        {
            foreach (var enemy in _enemies)
            {
                if (enemy != null)
                    UnSubscribeEnemy(enemy);
            }
        }
    }
}