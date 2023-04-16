using System;
using Assets.Sources.Enemy.SpiderSources.Services;

namespace Assets.Sources.Presentation.View
{
    public class EnemiesLeftViewAdapter : IDisposable
    {
        private readonly SpiderSpawnService _spiderSpawnService;
        private readonly ScoreView _scoreView;

        public EnemiesLeftViewAdapter(SpiderSpawnService spiderSpawnService, ScoreView scoreView)
        {
            _spiderSpawnService = spiderSpawnService;
            _scoreView = scoreView;

            _spiderSpawnService.EnemiesCountChanged += OnEnemiesCountChanged;
            OnEnemiesCountChanged(_spiderSpawnService.SpiderCount);
        }

        private void OnEnemiesCountChanged(int count)
        {
            _scoreView.SetScore(count.ToString());
        }

        public void Dispose()
        {
            _spiderSpawnService.EnemiesCountChanged -= OnEnemiesCountChanged;
        }
    }
}