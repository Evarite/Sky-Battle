using DG.Tweening;
using Lab.Managers;
using UnityEngine;
using VContainer;

namespace Lab.End
{
    [RequireComponent(typeof(CanvasGroup))]
    public class EndScreenAppear : MonoBehaviour
    {
        [SerializeField] private float _fadeTime = 1f;

        [Inject] private GameStopManager _stopManager;

        private CanvasGroup _canvasGroup;

        private float _finalOpacity = 1f;

        private void Awake() => _canvasGroup = GetComponent<CanvasGroup>();

        private void OnEnable() => _stopManager.OnGameFinished += ShowEndScreen;

        private void OnDisable() => _stopManager.OnGameFinished -= ShowEndScreen;

        private void ShowEndScreen() => _canvasGroup.DOFade(_finalOpacity, _fadeTime);
    }
}