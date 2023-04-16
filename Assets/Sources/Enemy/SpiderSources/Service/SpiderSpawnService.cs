using System;
using Assets.Sources.Common.Service;
using Assets.Sources.Domain;
using Assets.Sources.Domain.Factory;
using Assets.Sources.Enemy.SpiderSources.Data.Repository;
using Assets.Sources.Enemy.SpiderSources.Domain;
using Assets.Sources.Presentation.Presenter;
using UnityEngine;

namespace Assets.Sources.Enemy.SpiderSources.Services
{
    public class SpiderSpawnService : UpdatableService
    {
        private readonly Score _score;
        private readonly SpiderFactory _spiderFactory;
        private readonly SpiderRepository _spiderRepository = new SpiderRepository();

        private Cooldown _spawnCooldown;

        private readonly int _maxSpiders = 50;

        public SpiderSpawnService(Score score, TreasureProvider treasureProvider)
        {
            _spiderFactory = new SpiderFactory(treasureProvider);
            _score = score;
            _spawnCooldown = new Cooldown(1, Create);
        }

        public event Action<int> EnemiesCountChanged;

        public int SpiderCount => _spiderRepository.Count;

        public override void OnUpdate()
        {
//            if(_spiderRepository.Count < _maxSpiders)
            _spawnCooldown.Update();
        }

        public override void OnEnable()
        {
        }

        private void Create()
        {
            Spider spider = _spiderFactory.Create();
            _spiderRepository.Add(spider);
            spider.Died += OnSpiderDied;

            EnemiesCountChanged?.Invoke(_spiderRepository.Count);
        }

        private void OnSpiderDied(Spider spider)
        {
            spider.Died -= OnSpiderDied;
            _spiderRepository.Remove(spider);

            _score.Add(100);

            EnemiesCountChanged?.Invoke(_spiderRepository.Count);
        }
    }
}