using UnityEngine;

namespace Assets.Sources.Presentation.View
{
    public class GameHud :MonoBehaviour
    {
        [field: SerializeField] public ScoreView EnemiesLeftView { get; private set; }
        [field: SerializeField] public ScoreView PlayerScoreView { get; private set; }
    }
}