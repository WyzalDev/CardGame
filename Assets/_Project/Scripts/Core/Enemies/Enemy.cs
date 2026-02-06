using System;
using _Project.Core.Behaviors;
using UnityEngine;

namespace _Project.Core.Enemies
{
    public class Enemy : IDamageable
    {
        public Action OnDeath { get; set; }

        public string Name { get; private set; }
        public Sprite Sprite { get; private set; }
        public int MaxHealth { get; private set; }
        public int Health { get; set; }

        public Enemy(string name, Sprite sprite, int maxHealth, int health = 0)
        {
            Name = name;
            Sprite = sprite;
            MaxHealth = maxHealth;
            Health = health == 0 ? MaxHealth : health;
        }

        public Enemy(Enemy enemy)
        {
            Name = enemy.Name;
            Sprite = enemy.Sprite;
            MaxHealth = enemy.MaxHealth;
            Health = enemy.MaxHealth;
        }

        public void DealDamage(int damage)
        {
            if (damage > 0)
                Health -= damage;

            if (Health <= 0)
                OnDeath?.Invoke();
        }
    }
}