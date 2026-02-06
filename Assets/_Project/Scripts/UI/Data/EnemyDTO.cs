using _Project.Core.Enemies;
using UnityEngine;

namespace _Project.UI.Data
{
    public struct EnemyDTO
    {
        public string Name;
        public Sprite Sprite;
        public int MaxHealth;
        public int Health;

        public static EnemyDTO EnemyToDTO(Enemy enemy)
        {
            return new EnemyDTO
            {
                Name = enemy.Name,
                Sprite = enemy.Sprite,
                Health = enemy.Health,
                MaxHealth = enemy.MaxHealth
            };
        }
    }
}