using Lab.HealthSystem;
using Lab.Managers;
using UnityEngine;
using VContainer;

namespace Lab.Enemies
{
    public class EnemyHealthBarParent : MonoBehaviour
    {
        [Inject] private GameStopManager _gameStopManager;

        private EnemyHealthBar _healthBar;
        private Health _health;

        private void Awake() => _healthBar = GetComponentInChildren<EnemyHealthBar>();

        private void OnDisable()
        {
            _health.OnDamageTaken -= ShowBar;
            _health.OnDeath -= HideBar;
            _gameStopManager.OnGameFinished -= HideBar;
        }

        private void HideBar() => _healthBar.gameObject.SetActive(false);

        private void ShowBar(float damage, float remainingHp) => _healthBar.gameObject.SetActive(true);

        public void Initialize(Health health)
        {
            _health = health;

            _health.OnDamageTaken += ShowBar;
            _health.OnDeath += HideBar;
            _gameStopManager.OnGameFinished += HideBar;

            _healthBar.Initialize(_health);
            HideBar();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (GetComponentInChildren<EnemyHealthBar>() == null)
                Debug.LogError($"[{name}]: EnemyHealthBar is missing in children!");
        }
#endif
    }
}