using UnityEngine;

namespace Lab.Pooling
{
    [CreateAssetMenu(menuName = "Lab/Pooling/Pool Data", fileName = "NewPool")]
    public class PoolData : ScriptableObject
    {
        [SerializeField] private PooledEntity _prefab;
        [SerializeField] private int _poolSize = 20;
        [SerializeField] private bool _canGrow = false;

        public PooledEntity Prefab => _prefab;
        public int PoolSize => _poolSize;
        public bool CanGrow => _canGrow;
    }
}