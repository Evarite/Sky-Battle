using Lab.HealthSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lab.Enemies
{
    [RequireComponent(typeof(Health))]
    public class EnemyHealthBarFollow : MonoBehaviour
    {
        [SerializeField] private EnemyHealthBarParent _healthBarPrefab;
        [SerializeField] private float _offsetY = 1.5f;

        [Inject] private RectTransform _canvasTransform;
        [Inject] private IObjectResolver _resolver;

        private RectTransform _healthBarTransform;

        private Camera _camera;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();

            _camera = Camera.main;

            var healthBar = _resolver.Instantiate(_healthBarPrefab, _canvasTransform);
            healthBar.Initialize(_health);

            _healthBarTransform = healthBar.transform as RectTransform;
        }

        private void LateUpdate()
        {
            Vector2 worldPosition = transform.position + Vector3.up * _offsetY;
            Vector2 screenPos = _camera.WorldToScreenPoint(worldPosition);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasTransform, screenPos,
                _camera, out var localPos);

            _healthBarTransform.anchoredPosition = localPos;
        }
    }
}