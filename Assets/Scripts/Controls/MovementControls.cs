using Lab.Managers;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace Lab.Controls
{
    public class MovementControls : MonoBehaviour
    {
        [Header("Movement Parameters")]
        [SerializeField] private float _speed;

        [Header("Screen Borders")]
        [SerializeField] private float _minX = -5;
        [SerializeField] private float _minY = -5;
        [SerializeField] private float _maxX = 5;
        [SerializeField] private float _maxY = 5;

        [Inject] private InputManager _inputManager;

        private Vector2 _direction = Vector2.zero;

        private void OnEnable()
        {
            _inputManager.InputActions.Player.Move.performed += OnMovement;
            _inputManager.InputActions.Player.Move.canceled += OnMovement;
        }

        private void OnDisable()
        {
            _inputManager.InputActions.Player.Move.performed -= OnMovement;
            _inputManager.InputActions.Player.Move.canceled -= OnMovement;

            _direction = Vector2.zero;
        }

        private void Update()
        {
            var newPos = transform.localPosition;
            newPos += (Vector3)_direction.normalized * _speed * Time.deltaTime;

            newPos.x = Mathf.Clamp(newPos.x, _minX, _maxX);
            newPos.y = Mathf.Clamp(newPos.y, _minY, _maxY);

            transform.localPosition = newPos;
        }

        private void OnMovement(InputAction.CallbackContext callbackContext) =>
            _direction = callbackContext.ReadValue<Vector2>();
    }
}