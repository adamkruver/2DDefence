using System;
using Assets.Sources.Domain;

namespace Assets.Sources.Presentation.View
{
    public class PlayerScoreViewAdapter : IDisposable
    {
        private readonly Score _score;
        private readonly ScoreView _scoreView;

        public PlayerScoreViewAdapter(Score score, ScoreView scoreView)
        {
            _score = score;
            _scoreView = scoreView;

            _score.Changed += OnPlayerScoreChanged;
            OnPlayerScoreChanged(_score.Value);
        }

        private void OnPlayerScoreChanged(int score)
        {
            _scoreView.SetScore(score.ToString());
        }

        public void Dispose()
        {
            _score.Changed -= OnPlayerScoreChanged;
        }
    }
}