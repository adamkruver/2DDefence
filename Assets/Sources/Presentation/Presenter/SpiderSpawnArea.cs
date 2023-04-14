using UnityEngine;

namespace DefaultNamespace
{
    public class SpiderSpawnArea : MonoBehaviour
    {
        [SerializeField] private Transform _from;
        [SerializeField] private Transform _to;

        public Vector2 GetSpawnPosition()
        {
            Vector2 from = _from.position;
            Vector2 to = _to.position;

            Vector2 direction = from - to;
            return to + direction * Random.Range(0f, 1f);
        }
    }
}