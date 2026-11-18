using System;
using UnityEngine;

namespace Lab.HealthSystem
{
    public class Health : MonoBehaviour, IHittable
    {
        [SerializeField] private float _maxHp = 100f;

        private float _hp;

        public delegate void DamageHandler(float damage, float remainingHp);
        public event DamageHandler OnDamageTaken;
        public event Action OnRevived;
        public event Action OnDeath;

        public float MaxHp => _maxHp;

        public float Hp => _hp;

        private void Awake() => Revive();

        public void TakeHit(float damage)
        {
            _hp = Mathf.Max(0f, _hp - damage);
            OnDamageTaken?.Invoke(damage, _hp);

            if (Hp <= 0)
                OnDeath?.Invoke();
        }

        public void Revive()
        {
            _hp = _maxHp;
            OnRevived?.Invoke();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (GetComponent<BaseDeathHandler>() == null)
                Debug.LogError($"[{name}]: BaseDeathHandler component is missing!");
        }
#endif
    }
}