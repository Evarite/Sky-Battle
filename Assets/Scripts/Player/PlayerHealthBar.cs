using Lab.HealthSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Lab.Player
{
    [RequireComponent(typeof(Slider))]
    public class PlayerHealthBar : BaseHealthBar
    {
        [SerializeField] private Health _health;

        private void Awake() => Initialize(_health);

        protected override void OnEnable()
        {
            base.OnEnable();

            _health.OnRevived += SyncValue;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _health.OnRevived -= SyncValue;
        }
    }
}