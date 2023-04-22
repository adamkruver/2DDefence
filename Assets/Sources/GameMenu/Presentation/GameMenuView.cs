using Sources.Common.Presentatin;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.GameMenu.Presentation
{
    public class GameMenuView: MonoBehaviour, IView
    {
        [SerializeField] private Button _startMenuButton;

        private IGameMenuPresenter _presenter;

        public void Show(object presenter)
        {
            if(presenter is not IGameMenuPresenter gameMenuPresenter)
                return;
            
            _presenter = gameMenuPresenter;
            
            Show();
        }

        public void Show()
        {
            _startMenuButton.onClick.AddListener(_presenter.OnStartGameClick);
        }

        public void Hide()
        {
            _startMenuButton.onClick.RemoveListener(_presenter.OnStartGameClick);
        }
    }
}