using Lab.Managers;
using Lab.Score;
using TMPro;
using UnityEngine;
using VContainer;

namespace Lab.End
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreResultTextSync : MonoBehaviour
    {
        [Inject] private ScoreCounter _counter;
        [Inject] private GameStopManager _stopManager;

        private TextMeshProUGUI _text;

        private void Awake() => _text = GetComponent<TextMeshProUGUI>();

        private void OnEnable() => _stopManager.OnGameFinished += SyncText;

        private void OnDisable() => _stopManager.OnGameFinished -= SyncText;

        private void SyncText() => _text.text = _counter.Score.ToString();
    }
}