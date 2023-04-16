using Assets.Sources.Common.Service;
using Assets.Sources.Presentation.View;
using Sources.Data.Repository;
using UnityEngine;

namespace Assets.Sources.Services
{
    public class ViewService: AbstractService
    {
        private readonly ViewRepository _viewRepository = new ViewRepository();

        public GameHud Hud => _viewRepository.GameHud;        
        
        public override void Initialize()
        {
            _viewRepository.GameHud = GameObject.FindObjectOfType<GameHud>();
        }
    }
}