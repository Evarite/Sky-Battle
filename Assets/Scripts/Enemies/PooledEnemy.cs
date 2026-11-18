using Lab.HealthSystem;
using Lab.Pooling;
using UnityEngine;

namespace Lab.Enemies
{
    [RequireComponent(typeof(Health))]
    public class PooledEnemy : PooledEntity
    {
        private Health _health;

        private void Awake() => _health = GetComponent<Health>();

        public override void OnSpawn() => _health.Revive();
    }
}