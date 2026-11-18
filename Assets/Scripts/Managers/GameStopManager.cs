using Lab.HealthSystem;
using System;
using UnityEngine;

namespace Lab.Managers
{
    public class GameStopManager : IDisposable
    {
        private Health _playerHealth;

        public event Action OnGameFinished;

        public GameStopManager(Health playerHealth)
        {
            Debug.Log("Initialized");

            _playerHealth = playerHealth;

            _playerHealth.OnDeath += OnPlayerDeath;
        }

        private void OnPlayerDeath() => OnGameFinished?.Invoke();

        public void Dispose() => _playerHealth.OnDeath -= OnPlayerDeath;
    }
}