using UnityEngine;

namespace Assets.Sources.Presentation.Presenter
{
    public class TreasureProvider
    {
        private TreasurePresenter _presenter;
        
        public Transform Transform => _presenter.transform;

        public void Set(TreasurePresenter presenter)
        {
            _presenter = presenter;
        }
    }
}