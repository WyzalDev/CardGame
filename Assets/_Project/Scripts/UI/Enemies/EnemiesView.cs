using _Project.UI.Data;
using UnityEngine;

namespace _Project.UI.Enemies
{
    public class EnemiesView : MonoBehaviour
    {
        [SerializeField] private EnemyView[] _enemyViews;

        public void SetEnemies(EnemyDTO[] enemies)
        {
            EnableViews(enemies.Length);

            for (var i = 0; i < enemies.Length; i++)
            {
                UpdateEnemyUI(enemies[i], _enemyViews[i].UI);
                UpdateEnemySlot(enemies[i], _enemyViews[i].Slot);
            }
        }

        public void UpdateEnemyHp(int index, int currentHp, int maxHp)
        {
            if (!CheckForOutOfRange(index))
                return;

            var enemyUIView = _enemyViews[index].UI;
            enemyUIView.SetMaxHp(maxHp);
            enemyUIView.SetHp(currentHp);
        }

        public void DisableView(int index)
        {
            if (!CheckForOutOfRange(index))
                return;

            var enemyView = _enemyViews[index];
            enemyView.UI.gameObject.SetActive(false);
            enemyView.Slot.gameObject.SetActive(false);
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

        private void UpdateEnemyUI(EnemyDTO enemy, EnemyUIView enemyUIView)
        {
            enemyUIView.SetName(enemy.Name);
            enemyUIView.SetMaxHp(enemy.MaxHealth);
            enemyUIView.SetHp(enemy.Health);
        }

        private void UpdateEnemySlot(EnemyDTO enemy, EnemySlotView enemySlotView)
        {
            enemySlotView.SetTitle(enemy.Name);
            enemySlotView.SetSprite(enemy.Sprite);
        }

        private bool CheckForOutOfRange(int index)
        {
            if (index < _enemyViews.Length)
                return true;

            Debug.LogError("Index out of range");
            return false;
        }
    }
}