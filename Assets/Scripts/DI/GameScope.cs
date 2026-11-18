using Lab.Controls;
using Lab.End;
using Lab.HealthSystem;
using Lab.Managers;
using Lab.Pooling;
using Lab.Restart;
using Lab.Score;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lab.DI
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private PoolData[] _pools;
        [SerializeField] private Transform _player;
        [SerializeField] private RectTransform _canvasTransform;
        [SerializeField] private Health _playerHealth;
        [SerializeField] private Camera _camera;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_player);
            builder.RegisterInstance(_canvasTransform);
            builder.RegisterInstance(_pools);
            builder.RegisterInstance(_playerHealth);
            builder.RegisterInstance(_camera);

            //GameStop
            builder.RegisterEntryPoint<GameStopManager>().AsSelf();

            //Pooling
            builder.RegisterEntryPoint<PoolService>().AsSelf();

            //Input
            builder.Register<InputManager>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<MovementControls>();
            builder.RegisterComponentInHierarchy<AttackControls>();

            //Score
            builder.Register<ScoreCounter>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<ScoreHUD>();

            //End Screen
            builder.RegisterComponentInHierarchy<EndScreenAppear>();
            builder.RegisterComponentInHierarchy<ScoreResultTextSync>();

            //Restart
            builder.RegisterComponentInHierarchy<ActivateRestartButton>();
            builder.RegisterComponentInHierarchy<RestartButtonClick>();

#if UNITY_EDITOR
            //Debug
            //builder.RegisterComponentInHierarchy<DebugSpawnManager>();
#endif
        }
    }
}