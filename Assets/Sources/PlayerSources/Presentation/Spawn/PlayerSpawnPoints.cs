using UnityEngine;

namespace Assets.Sources.PlayerSources.Presentation.Spawn
{
    public class PlayerSpawnPoints : MonoBehaviour
    {
        [field: SerializeField] public Transform[] SpawnPoints { get; private set; }
    }
}