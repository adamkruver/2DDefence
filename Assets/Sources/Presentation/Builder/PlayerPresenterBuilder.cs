using Assets.Sources.Presentation.Factory;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerPresenterBuilder
    {
        private Factory<PlayerPresenter> _playerPresenterFactory = new Factory<PlayerPresenter>();
        private PlayerSpawnPoints _playerSpawnPoints;

        public PlayerPresenterBuilder()
        {
            _playerSpawnPoints = new Factory<PlayerSpawnPoints>().Create();
        }

        public PlayerPresenter Build(int spawnIndex)
        {
            PlayerPresenter playerPresenter = _playerPresenterFactory.Create();

            spawnIndex %= _playerSpawnPoints.SpawnPoints.Length;
            Vector3 spawnPoint = _playerSpawnPoints.SpawnPoints[spawnIndex].position;
            playerPresenter.SetPosition(spawnPoint);

            return playerPresenter;
        }
    }
}