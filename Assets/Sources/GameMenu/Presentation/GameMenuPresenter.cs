using System;

namespace Sources.GameMenu.Presentation
{
    public class GameMenuPresenter : IGameMenuPresenter
    {
        private readonly Action _action;

        public GameMenuPresenter(Action action)
        {
            _action = action;
        }

        public void OnStartGameClick()
        {
            _action.Invoke();
        }
    }
}