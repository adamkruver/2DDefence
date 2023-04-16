using Assets.Sources.Enemy.SpiderSources.Domain;
using Assets.Sources.Enemy.SpiderSources.Presentation.Builder;
using Assets.Sources.Enemy.SpiderSources.Presentation.Presenter;
using Assets.Sources.Presentation.Presenter;

namespace Assets.Sources.Domain.Factory
{
    public class SpiderFactory
    {
        private readonly SpiderPresenterBuilder _spiderPresenterBuilder;

        public SpiderFactory(TreasureProvider treasureProvider)
        {
            _spiderPresenterBuilder = new SpiderPresenterBuilder(treasureProvider);
        }

        public Spider Create()
        {
            Spider spider = new Spider();
            SpiderPresenter spiderPresenter = _spiderPresenterBuilder.Build(spider);
            
            return spider;
        }
    }
}