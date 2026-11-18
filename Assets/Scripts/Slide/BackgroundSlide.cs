using Lab.Managers;
using Lab.Restart;
using UnityEngine;
using VContainer;

namespace Lab.Slide
{
    [RequireComponent(typeof(MeshRenderer))]
    public class BackgroundSlide : MonoBehaviour
    {
        [SerializeField] private float _speed;

        [Inject] private GameStopManager _gameStop;
        [Inject] private RestartButtonClick _restartButton;

        private Material _material;
        private float _offset = 0f;
        private float _currentSpeed = 0f;

        private void Awake()
        {
            _material = GetComponent<MeshRenderer>().material;

            _currentSpeed = _speed;
        }

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

        private void Update()
        {
            _offset += _currentSpeed * Time.deltaTime;
            _material.mainTextureOffset = new Vector2(Mathf.Repeat(_offset, 1f), 0f);
        }

        private void OnGameFinished() => _currentSpeed = 0f;

        private void OnRestart() => _currentSpeed = _speed;
    }
}