using _Project.Core.Enemies;
using UnityEngine;

namespace _Project.UI.Enemies
{
    public class EnemiesView : MonoBehaviour
    {
        [SerializeField] private EnemyView[] _enemyViews;

        public void SetEnemies(Enemy[] enemies)
        {
            EnableViews(enemies.Length);

            for (var i = 0; i < enemies.Length; i++)
            {
                UpdateEnemyUI(enemies[i], _enemyViews[i].UI);
                UpdateEnemySlot(enemies[i], _enemyViews[i].Slot);
            }
        }

        private void EnableViews(int count)
        {
            for (var i = 0; i < _enemyViews.Length; i++)
            {
                var enemyView = _enemyViews[i];
                enemyView.UI.gameObject.SetActive(i  < count);
                enemyView.Slot.gameObject.SetActive(i  < count);
            }
        }

        private void UpdateEnemyUI(Enemy enemy, EnemyUIView enemyUIView)
        {
            enemyUIView.SetName(enemy.Name);
            enemyUIView.SetMaxHp(enemy.MaxHealth);
            enemyUIView.SetHp(enemy.Health);
        }

        private void UpdateEnemySlot(Enemy enemy, EnemySlotView enemySlotView)
        {
            enemySlotView.SetTitle(enemy.Name);
            enemySlotView.SetSprite(enemy.Sprite);
        }
    }
}