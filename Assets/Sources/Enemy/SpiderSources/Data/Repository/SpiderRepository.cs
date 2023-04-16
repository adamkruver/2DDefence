using System.Collections.Generic;
using Assets.Sources.Enemy.SpiderSources.Domain;

namespace Assets.Sources.Enemy.SpiderSources.Data.Repository
{
    public class SpiderRepository
    {
        private readonly List<Spider> _spiders = new List<Spider>();

        public int Count => _spiders.Count;

        public void Add(Spider spider)
        {
            _spiders.Add(spider);
        }

        public void Remove(Spider spider)
        {
            _spiders.Remove(spider);
        }
    }
}