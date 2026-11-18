using UnityEngine;

namespace Lab.HealthSystem
{
    [RequireComponent(typeof(Health))]
    public abstract class BaseDeathHandler : MonoBehaviour
    {
        private Health _health;

        protected virtual void Awake() => _health = GetComponent<Health>();

        protected virtual void OnEnable() => _health.OnDeath += Die;

        protected virtual void OnDisable() => _health.OnDeath -= Die;

        protected abstract void Die();
    }
}