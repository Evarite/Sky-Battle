using Lab.Pooling;
using UnityEngine;

namespace Lab.Shooting
{
    [CreateAssetMenu(menuName = "Lab/Attack/Attack Data", fileName = "AttackData")]
    public class AttackData : ScriptableObject
    {
        [Header("Prefab")]
        [SerializeField] private PooledEntity _bulletPrefab;

        [Header("Damage")]
        [SerializeField] private float _damage;

        [Header("Time")]
        [SerializeField] private float _attackCooldown;

        [Header("Bullet Data")]
        [SerializeField] private float _speed;
        [SerializeField] private float _lifetime;

        [Header("Physics Layer")]
        [SerializeField] private LayerMask _collisionLayer;

        public PooledEntity BulletPrefab => _bulletPrefab;
        public float Damage => _damage;
        public float AttackCooldown => _attackCooldown;
        public float Speed => _speed;
        public float Lifetime => _lifetime;

        public LayerMask CollisionLayer => _collisionLayer;
    }
}