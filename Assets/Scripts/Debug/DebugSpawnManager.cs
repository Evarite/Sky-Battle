#if UNITY_EDITOR
using Lab.Pooling;
using System.Collections;
using UnityEngine;
using VContainer;

namespace Lab.Debugging
{
    public class DebugSpawnManager : MonoBehaviour
    {
        [SerializeField] private PooledEntity _enemyPrefab;
        [SerializeField] private Vector3 _spawnPosition;

        [Inject] private PoolService _poolService;

        private void Start() => StartCoroutine(Spawn());

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_poolService.TryGet(_enemyPrefab, out var entity))
                {
                    entity.transform.position = _spawnPosition;
                }

                yield return new WaitForSeconds(6f);
            }
        }
    }
}
#endif