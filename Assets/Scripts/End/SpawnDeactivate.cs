using Lab.HealthSystem;
using Lab.Managers.Spawn;
using UnityEngine;
using VContainer;

namespace Lab.End
{
    public class SpawnDeactivate : MonoBehaviour
    {
        [SerializeField] private SpawnManager[] _spawnManagers;

        [Inject] private Health _playerHealth;

        private void OnEnable() => _playerHealth.OnDeath += DisableSpawn;

        private void OnDisable() => _playerHealth.OnDeath -= DisableSpawn;

        private void DisableSpawn()
        {
            foreach (var manager in _spawnManagers)
                manager.enabled = false;
        }
    }
}