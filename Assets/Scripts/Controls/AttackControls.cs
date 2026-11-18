using Lab.Managers;
using Lab.Pooling;
using Lab.Shooting;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace Lab.Controls
{
    public class AttackControls : MonoBehaviour
    {
        [SerializeField] private AttackData _data;

        [Inject] private InputManager _inputManager;
        [Inject] private PoolService _poolService;

        private Vector2 _mouseDirection;

        private Coroutine _attack;

        private WaitForSeconds _attackCooldown;

        private void Awake() => _attackCooldown = new(_data.AttackCooldown);

        private void OnEnable() => _inputManager.InputActions.Player.Attack.performed += Attack;

        private void OnDisable() => _inputManager.InputActions.Player.Attack.performed -= Attack;

        private void Attack(InputAction.CallbackContext callbackContext)
        {
            Vector2 screenPos = Mouse.current.position.ReadValue();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

            _mouseDirection = worldPos - transform.position;

            _attack ??= StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            if (_poolService.TryGet(_data.BulletPrefab, out var entity))
            {
                float angle = Mathf.Atan2(_mouseDirection.y, _mouseDirection.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

                entity.transform.position = transform.position;
                entity.transform.rotation = rotation;

                var bullet = entity.gameObject.GetComponent<Bullet>();
                bullet.Initialize(_data);

                yield return _attackCooldown;
            }

            _attack = null;
        }
    }
}