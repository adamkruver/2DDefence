using DefaultNamespace;
using Sources.Bootstrap;
using UnityEngine;

namespace Assets.Sources.Services
{
    public class SpiderSpawnService: IUpdatable
    {
        private readonly SpiderPresenterBuilder _spiderPresenterBuilder = new SpiderPresenterBuilder();
        
        public void Enable()
        {
            SpiderPresenter spiderPresenter = _spiderPresenterBuilder.Build();
        }

        public void Update()
        {
        }
    }
}