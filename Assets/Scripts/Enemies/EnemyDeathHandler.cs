using Lab.HealthSystem;
using Lab.Pooling;
using Lab.Score;
using UnityEngine;
using VContainer;

namespace Lab.Enemies
{
    [RequireComponent(typeof(PooledEntity))]
    public class EnemyDeathHandler : BaseDeathHandler
    {
        [SerializeField] private PooledEntity _deathEffectPrefab;

        [Inject] private PoolService _poolService;
        [Inject] private ScoreCounter _scoreCounter;

        private PooledEntity _entity;

        protected override void Awake()
        {
            base.Awake();
            _entity = GetComponent<PooledEntity>();
        }

        protected override void Die()
        {
            _scoreCounter.Score++;

            if (_poolService.TryGet(_deathEffectPrefab, out var effect))
            {
                effect.transform.position = transform.position;
                effect.GetComponent<ParticleSystem>().Play();
            }

            _entity.Return();
        }
    }
}
