using Lab.HealthSystem;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Lab.Restart
{
    [RequireComponent(typeof(Button))]
    public class ActivateRestartButton : MonoBehaviour
    {
        [Inject] private Health _playerHealth;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _playerHealth.OnDeath += OnDeath;

        private void OnDisable() => _playerHealth.OnDeath -= OnDeath;

        private void OnDeath() => _button.enabled = true;
    }
}