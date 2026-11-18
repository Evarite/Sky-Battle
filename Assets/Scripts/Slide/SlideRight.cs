using Lab.Managers;
using Lab.Restart;
using UnityEngine;
using VContainer;

namespace Lab.Slide
{
    public class SlideRight : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;

        [Inject] private GameStopManager _gameStop;
        [Inject] private RestartButtonClick _restartButton;

        private float _currentSpeed = 0f;

        private void Awake() => _currentSpeed = _speed;

        private void OnEnable()
        {
            _gameStop.OnGameFinished += OnGameFinished;
            _restartButton.OnRestart += OnRestart;
        }

        private void OnDisable()
        {
            _gameStop.OnGameFinished -= OnGameFinished;
            _restartButton.OnRestart -= OnRestart;
        }

        private void LateUpdate() => transform.position += _currentSpeed *
            Time.deltaTime * Vector3.right;

        private void OnGameFinished() => _currentSpeed = 0f;

        private void OnRestart() => _currentSpeed = _speed;
    }
}