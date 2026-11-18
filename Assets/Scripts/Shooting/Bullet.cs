using Lab.HealthSystem;
using Lab.Pooling;
using System.Collections;
using UnityEngine;

namespace Lab.Shooting
{
    [RequireComponent(typeof(Collider2D))]
    public class Bullet : PooledEntity
    {
        private AttackData _attackData;

        private Collider2D _collider;

        private WaitForSeconds _waitLifetime;

        private void Awake() => _collider = GetComponent<Collider2D>();

        public void Initialize(AttackData data)
        {
            _attackData = data;

            _collider.includeLayers = _attackData.CollisionLayer;
            _collider.excludeLayers = ~_attackData.CollisionLayer;

            _waitLifetime = new(_attackData.Lifetime);

            StartCoroutine(LifetimeReturn());
        }

        public override void OnDespawn() => StopAllCoroutines();

        private void Update() =>
            transform.position += transform.rotation * Vector2.right * _attackData.Speed * Time.deltaTime;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<IHittable>(out var hittable))
            {
                hittable.TakeHit(_attackData.Damage);
                Return();
            }
        }

        private IEnumerator LifetimeReturn()
        {
            //yield return new WaitForSeconds(_attackData.Lifetime);
            yield return _waitLifetime;

            Return();
        }
    }
}