using System;
using _Project.Core.Enemies;
using _Project.UI.Data;
using _Project.UI.Enemies;
using UnityEngine;
using Zenject;

namespace _Project.Presenters
{
    public class EnemiesPresenter : IInitializable, IDisposable
    {
        private EnemiesView _view;
        private EnemiesModel _model;

        private EnemyDTO[] _enemies;

        [Inject]
        public EnemiesPresenter(EnemiesView view, EnemiesModel model, int maxEnemiesCount)
        {
            _enemies = new EnemyDTO[maxEnemiesCount];
            _view = view;
            _model = model;
            Debug.Log($"Creating {maxEnemiesCount} enemiesDTO");
        }

        public void Initialize()
        {
            Debug.Log($"Initializing");
            _model.OnEnemiesReset += OnEnemiesReset;
            _model.OnSlotEnemyDeath += OnSlotEnemyDeath;

            _model.ResetEnemies();
        }

        private void OnSlotEnemyDeath(int slotIndex, Enemy deadEnemy)
        {
            _view.UpdateEnemyHp(slotIndex, 0, deadEnemy.MaxHealth);
            _view.DisableView(slotIndex);
        }

        private void OnEnemiesReset()
        {
            ConvertEnemiesToDTOs(_model.Enemies);
            _view.SetEnemies(_enemies);
        }

        private void ConvertEnemiesToDTOs(Enemy[] enemies)
        {
            for (var i = 0; i < enemies.Length; i++)
                _enemies[i] = EnemyDTO.EnemyToDTO(enemies[i]);
        }

        public void Dispose()
        {
            _model.OnEnemiesReset -= OnEnemiesReset;
            _model.OnSlotEnemyDeath -= OnSlotEnemyDeath;
        }
    }
}