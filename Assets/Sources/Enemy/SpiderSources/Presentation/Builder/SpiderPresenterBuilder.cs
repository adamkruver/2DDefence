using Assets.Sources.Common.Factory;
using Assets.Sources.Enemy.SpiderSources.Domain;
using Assets.Sources.Enemy.SpiderSources.Presentation.Presenter;
using Assets.Sources.Presentation.Presenter;
using Sources.Common.Pool;

namespace Assets.Sources.Enemy.SpiderSources.Presentation.Builder
{
    public class SpiderPresenterBuilder
    {
        private readonly TreasureProvider _treasureProvider;
        private readonly IFactory<SpiderPresenter> _spiderPresenterFactory = new Factory<SpiderPresenter>();
        private readonly GameObjectPool<SpiderPresenter> _spiderPool;
        private readonly SpiderSpawnArea _spiderSpawnArea;

        public SpiderPresenterBuilder(TreasureProvider treasureProvider)
        {
            _treasureProvider = treasureProvider;
            _spiderSpawnArea = new Factory<SpiderSpawnArea>().Create();

            _spiderPool = new GameObjectPool<SpiderPresenter>(() => _spiderPresenterFactory.Create());
        }

        public SpiderPresenter Build(Spider spider)
        {
            SpiderPresenter spiderPresenter = _spiderPool.Get();
            spiderPresenter.Construct(spider, _treasureProvider, _spiderSpawnArea.GetSpawnPosition());
            return spiderPresenter;
        }
    }
}