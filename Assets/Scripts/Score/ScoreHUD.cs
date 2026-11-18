using TMPro;
using UnityEngine;
using VContainer;

namespace Lab.Score
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreHUD : MonoBehaviour
    {
        [Inject] private ScoreCounter _counter;

        private TextMeshProUGUI _text;

        private void Awake() => _text = GetComponent<TextMeshProUGUI>();

        private void OnEnable() => _counter.OnScoreChanged += UpdateScore;

        private void OnDisable() => _counter.OnScoreChanged -= UpdateScore;

        private void UpdateScore(int score) => _text.text = score.ToString();
    }
}