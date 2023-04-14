using Assets.Sources.Presentation.Factory;

namespace DefaultNamespace
{
    public class SpiderPresenterBuilder
    {
        private readonly IFactory<SpiderPresenter> _spiderPresenterFactory = new Factory<SpiderPresenter>();
        private readonly SpiderSpawnArea _spiderSpawnArea;
        private readonly TreasurePresenter _treasurePresenter;

        public SpiderPresenterBuilder()
        {
            _spiderSpawnArea = new Factory<SpiderSpawnArea>().Create();
            _treasurePresenter = new Factory<TreasurePresenter>().Create();
        }

        public SpiderPresenter Build()
        {
            SpiderPresenter spiderPresenter = _spiderPresenterFactory.Create();
            spiderPresenter.Construct(_treasurePresenter, _spiderSpawnArea.GetSpawnPosition());
            return spiderPresenter;
        }
    }
}