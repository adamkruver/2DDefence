using System;
using System.Collections.Generic;
using Assets.Sources.Common.Service;
using Assets.Sources.PlayerSources.Domain;
using Assets.Sources.PlayerSources.Presentation.Builder;
using Assets.Sources.PlayerSources.Presentation.Presenter;
using Assets.Sources.Presentation.Presenter;
using Assets.Sources.Services;
using UnityEngine;

namespace Assets.Sources.PlayerSources.Services
{
    public class PlayerService : AbstractService
    {
        private readonly MovementService _movementService;
        private readonly List<Player> _players = new List<Player>();
        private readonly List<PlayerPresenter> _playerPresenters = new List<PlayerPresenter>();
        private readonly PlayerPresenterBuilder _playerPresenterBuilder = new PlayerPresenterBuilder();

        private int _selectedPlayerIndex = 0;
        private TreasureProvider _treasureProvider;

        public PlayerService(MovementService movementService)
        {
            _movementService = movementService;
        }

        public event Action<PlayerPresenter> PlayerChanged;

        private Player SelectedPlayer => _players[_selectedPlayerIndex];

        private PlayerPresenter SelectedPresenter => _playerPresenters[_selectedPlayerIndex];

        public void Clear()
        {
            foreach (PlayerPresenter player in _playerPresenters)
            {
                GameObject.Destroy(player.gameObject);
            }

            _players.Clear();
            _playerPresenters.Clear();
        }


        public void Move()
        {
            if (_players.Count > 0)
            {
                SelectedPresenter.Move(_movementService.Direction);
            }

            _movementService.Clear();
        }

        public void SelectNext()
        {
            if (_players.Count == 0)
                return;

            SelectedPresenter.Move(Vector2.zero);

            _selectedPlayerIndex++;

            if (_selectedPlayerIndex >= _players.Count)
                _selectedPlayerIndex = 0;

            NotifyObservers();
        }

        public void SelectPrev()
        {
            if (_players.Count == 0)
                return;

            SelectedPresenter.Move(Vector2.zero);

            _selectedPlayerIndex--;

            if (_selectedPlayerIndex < 0)
                _selectedPlayerIndex = _players.Count - 1;

            NotifyObservers();
        }

        public void CreatePlayer(int spawnIndex)
        {
            Player player = new Player();
            PlayerPresenter playerPresenter = _playerPresenterBuilder.Build(spawnIndex);
            playerPresenter.Construct(player, _treasureProvider);
            _players.Add(player);
            _playerPresenters.Add(playerPresenter);
        }

        private void NotifyObservers()
        {
            foreach (PlayerPresenter playerPresenter in _playerPresenters)
            {
                playerPresenter.SetSelected(SelectedPlayer);
            }

            PlayerChanged?.Invoke(SelectedPresenter);
        }

        public void SetTreasureProvider(TreasureProvider treasureProvider)
        {
            _treasureProvider = treasureProvider;
        }
    }
}