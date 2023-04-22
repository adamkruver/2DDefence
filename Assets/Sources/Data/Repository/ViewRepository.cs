using System.Collections.Generic;
using Assets.Sources.Common.Factory;
using Assets.Sources.Presentation.View;
using Sources.Common.Presentatin;
using Sources.GameMenu.Presentation;

namespace Sources.Data.Repository
{
    public class ViewRepository
    {
        private static Curtain _curtain;

        private readonly Stack<IView> _viewHistory = new Stack<IView>();
        
        private GameHud _gameHud;
        private GameMenuView _gameMenuView; 

        public GameHud GameHud => _gameHud ??= new Factory<GameHud>().Create();
        public Curtain Curtain => _curtain ??= new Factory<Curtain>().Create();
        
        public IView CurrentView { get; private set; }
        
        public GameMenuView GameMenuView => _gameMenuView ??= new Factory<GameMenuView>().Create();

        public void SetCurrentView(IView view)
        {

            if (CurrentView is not null)
            {
                CurrentView.Hide();
                _viewHistory.Push(CurrentView);
            }
                
            CurrentView = view;
        }

        public bool TryPop(out IView view)
        {
            return _viewHistory.TryPop(out view);
        }
    }
}