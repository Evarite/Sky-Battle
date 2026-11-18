using Lab.Pooling;
using System.Collections;
using UnityEngine;
using VContainer;

namespace Lab.Managers.Spawn
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private SpawnData _data;

        [Inject] private PoolService _poolService;
        [Inject] private Camera _camera;
        private Transform _cameraTransform;

        private WaitForSeconds _spawnInterval;

        private void Awake()
        {
            _spawnInterval = new(_data.SpawnIntervalTime);

            _cameraTransform = _camera.transform;
        }

        private void OnEnable() => StartCoroutine(Spawn());

        private void OnDisable() => StopAllCoroutines();

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return _spawnInterval;

                if (_poolService.TryGet(_data.Prefab, out var entity))
                {
                    float xDist = Random.Range(_data.MinXDist, _data.MaxXDist);
                    float y = Random.Range(_data.MinY, _data.MaxY);

                    Vector3 spawnPosition = new(_cameraTransform.position.x + xDist, y);

                    entity.transform.position = spawnPosition;
                }
            }
        }
    }
}