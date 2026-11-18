using Lab.Pooling;
using UnityEngine;

namespace Lab.Managers.Spawn
{
    [System.Serializable]
    public class SpawnData
    {
        [Header("Object")]
        [SerializeField] private PooledEntity _prefab;

        [Header("Spawn Settings")]
        [SerializeField] private float _minY = -7f;
        [SerializeField] private float _maxY = 7f;
        [SerializeField] private float _minXDist = 10f;
        [SerializeField] private float _maxXDist = 30f;
        [SerializeField] private float _spawnIntervalTime = 3.5f;

        public PooledEntity Prefab => _prefab;
        public float MinY => _minY;
        public float MaxY => _maxY;
        public float MinXDist => _minXDist;
        public float MaxXDist => _maxXDist;
        public float SpawnIntervalTime => _spawnIntervalTime;
    }
}
