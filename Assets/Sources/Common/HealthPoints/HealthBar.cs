using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Common.HealthPoints
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Color _maxHealthColor;
        [SerializeField] private Color _mediumHealthColor;
        [SerializeField] private Color _lowHealthColor;
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _image;
        
        private const float MaxValue = 1f; 

        public void Clear()
        {
            Set(MaxValue);
        }

        public void Set(float percent)
        {
            _slider.value = percent;

            SetColor(percent);
        }

        private void SetColor(float percent)
        {
            if (percent < .33f)
                _image.color = _lowHealthColor;
            else if (percent < .66f)
                _image.color = _mediumHealthColor;
            else
                _image.color = _maxHealthColor;
        }
    }
}