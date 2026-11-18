using System;

namespace Lab.Score
{
    public class ScoreCounter
    {
        private int _score;

        public event Action<int> OnScoreChanged;

        public int Score
        {
            get => _score;
            set
            {
                _score = value;

                OnScoreChanged?.Invoke(_score);
            }
        }
    }
}