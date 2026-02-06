using UnityEngine;

namespace _Project.Core.Enemies
{
    public class Enemy
    {
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
    }
}