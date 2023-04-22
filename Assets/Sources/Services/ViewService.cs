using System;
using Assets.Sources.Common.Factory;
using Assets.Sources.Common.Service;
using Assets.Sources.Presentation.View;
using Sources.Common.Presentatin;
using Sources.Data.Repository;
using Sources.GameMenu.Presentation;
using UnityEngine;

namespace Assets.Sources.Services
{
    public class ViewService: AbstractService
    {
        private ViewRepository _viewRepository;

        public GameHud Hud => ViewRepository.GameHud;
        public GameMenuView GameMenuView => ViewRepository.GameMenuView;

        private Curtain Curtain => ViewRepository.Curtain;
        private ViewRepository ViewRepository => _viewRepository ??= new ViewRepository();
        
        public void ShowCurtain()
        {
            Curtain.Show();
        }

        public void HideCurtain()
        {
            Curtain.Hide();
        }

        public override void OnDisable()
        {
            _viewRepository = null;
        }

        public void Show(IView view, object presenter)
        {
            _viewRepository.SetCurrentView(view);
            view.Show(presenter);
        }
        
        public void Show(IView view)
        {
            _viewRepository.SetCurrentView(view);
            view.Show();
        }

        public void HideView()
        {
            _viewRepository.CurrentView?.Hide();
        }

        public void ShowPreviousView()
        {
            if (_viewRepository.TryPop(out IView view))
            {
                _viewRepository.CurrentView.Hide();
                view.Show();
            }
        }
    }
}