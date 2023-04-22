using Assets.Sources.Common.Factory;
using Assets.Sources.Common.Service;
using Assets.Sources.Domain;
using Assets.Sources.Enemy.SpiderSources.Services;
using Assets.Sources.Presentation.Presenter;
using Assets.Sources.Presentation.View;

namespace Assets.Sources.Services
{
    public class GameService : UpdatableService
    {
        private readonly ViewService _viewService;
        private SpiderSpawnService _spiderSpawnService;
        private Score _score;
        private EnemiesLeftViewAdapter _enemiesLeftViewAdapter;
        private PlayerScoreViewAdapter _playerScoreViewAdapter;

        public GameService(ViewService viewService)
        {
            _viewService = viewService;
            TreasureProvider = new TreasureProvider();
            _score = new Score();
        }
        
        public TreasureProvider TreasureProvider { get; private set; }

        public override void Initialize()
        {
            TreasureProvider.Set(new Factory<TreasurePresenter>().Create());
            _spiderSpawnService = new SpiderSpawnService(_score, TreasureProvider);
        }

        public override void OnEnable()
        {
            _spiderSpawnService.Enable();
            _viewService.Enable();

            CreateAdapters();
        }

        public override void OnDisable()
        {
            DestroyAdapters();

            _spiderSpawnService.Disable();
            _viewService.Disable();
        }

        public override void OnUpdate()
        {
            _spiderSpawnService.Update();
        }

        public override void OnDispose()
        {
            DestroyAdapters();
        }

        private void CreateAdapters()
        {
            DestroyAdapters();

            _enemiesLeftViewAdapter = new EnemiesLeftViewAdapter(_spiderSpawnService, _viewService.Hud.EnemiesLeftView);
            _playerScoreViewAdapter = new PlayerScoreViewAdapter(_score, _viewService.Hud.PlayerScoreView);
        }

        private void DestroyAdapters()
        {
            _playerScoreViewAdapter?.Dispose();
            _enemiesLeftViewAdapter?.Dispose();

            _playerScoreViewAdapter = null;
            _enemiesLeftViewAdapter = null;
        }
    }
}