using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Assets.Sources.Presentation.View
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _score;

        public void SetScore(string score)
        {
            _score.text = score;

            DOTween.Sequence()
                .Append(_score.transform.DOScale(Vector3.one * 1.5f, .1f))
                .Append(_score.transform.DOScale(Vector3.one, .1f));
        }
    }
}