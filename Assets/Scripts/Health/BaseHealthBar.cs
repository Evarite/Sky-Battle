using UnityEngine;
using UnityEngine.UI;

namespace Lab.HealthSystem
{
    [RequireComponent(typeof(Slider))]
    public abstract class BaseHealthBar : MonoBehaviour
    {
        protected Health health;
        protected Slider slider;

        protected void Initialize(Health health)
        {
            this.health = health;

            slider = GetComponent<Slider>();

            slider.minValue = 0f;
            slider.maxValue = this.health.MaxHp;

            enabled = true;
        }

        protected virtual void OnEnable()
        {
            health.OnDamageTaken += OnDamageTaken;

            SyncValue();
        }

        protected virtual void OnDisable() => health.OnDamageTaken -= OnDamageTaken;

        private void OnDamageTaken(float damage, float remainingHp) =>
            slider.value = remainingHp;

        protected void SyncValue() => slider.value = health.Hp;
    }
}