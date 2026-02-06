using _Project.Core.Enemies;
using _Project.Presenters;
using _Project.UI.Enemies;
using UnityEngine;
using Zenject;

namespace _Project.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private EnemiesView _enemiesView;
        [SerializeField] private Sprite _enemySpriteExample;

        public override void InstallBindings()
        {
            BindEnemies();
        }

        private void BindEnemies()
        {
            Container.Bind<EnemiesView>().FromInstance(_enemiesView).AsSingle();

            var enemyExample = new Enemy("example", _enemySpriteExample, 100);
            Container.BindInterfacesAndSelfTo<EnemiesModel>().AsSingle().WithArguments(new SimpleEnemyGenerator(enemyExample), 3);

            Container.BindInterfacesAndSelfTo<EnemiesPresenter>().AsSingle().WithArguments(3).NonLazy();
        }
    }
}