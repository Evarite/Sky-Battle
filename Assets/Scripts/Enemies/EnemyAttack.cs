using Lab.Managers;
using Lab.Pooling;
using Lab.Shooting;
using System.Collections;
using UnityEngine;
using VContainer;

namespace Lab.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private AttackData _attackData;

        [Inject] private PoolService _poolService;
        [Inject] private Transform _player;
        [Inject] private GameStopManager _gameStop;

        private WaitForSeconds _attackCooldown;

        private void Awake() => _attackCooldown = new(_attackData.AttackCooldown);

        private void OnEnable()
        {
            StartCoroutine(Attack());

            _gameStop.OnGameFinished += OnGameFinished;
        }

        private void OnDisable()
        {
            StopAllCoroutines();

            _gameStop.OnGameFinished -= OnGameFinished;
        }

        private IEnumerator Attack()
        {
            while (true)
            {
                if (_poolService.TryGet(_attackData.BulletPrefab, out var entity))
                {
                    Vector2 direction = _player.position - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

                    entity.transform.position = transform.position;
                    entity.transform.rotation = rotation;

                    var bullet = entity.gameObject.GetComponent<Bullet>();
                    bullet.Initialize(_attackData);
                }

                yield return _attackCooldown;
            }
        }

        private void OnGameFinished() => enabled = false;
    }
}