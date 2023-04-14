using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerSpawnPoints : MonoBehaviour
    {
        [field: SerializeField] public Transform[] SpawnPoints { get; private set; }
    }
}