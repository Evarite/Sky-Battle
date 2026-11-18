using Lab.HealthSystem;
using Lab.Managers.Spawn;
using Lab.Pooling;
using Lab.Score;
using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Lab.Restart
{
    [RequireComponent(typeof(Button))]
    public class RestartButtonClick : MonoBehaviour
    {
        [SerializeField] private SpawnManager[] _spawnManagers;
        [SerializeField] private CanvasGroup _deathScreen;
        [SerializeField] private GameObject _player;
        [SerializeField] private Health _playerHealth;

        [Inject] private ScoreCounter _scoreCounter;
        [Inject] private PoolService _poolService;

        private Button _button;

        public event Action OnRestart;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(OnClick);

        private void OnDisable() => _button.onClick.RemoveListener(OnClick);

        private void OnClick()
        {
            _poolService.ReturnAll();

            foreach (var spawnManager in _spawnManagers)
                spawnManager.enabled = true;

            _scoreCounter.Score = 0;

            _deathScreen.alpha = 0f;

            _button.enabled = false;

            _playerHealth.Revive();
            _player.SetActive(true);

            OnRestart?.Invoke();
        }
    }
}