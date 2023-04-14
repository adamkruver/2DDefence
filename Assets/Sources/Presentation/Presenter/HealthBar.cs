using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Color _maxHealthColor;
        [SerializeField] private Color _mediumHealthColor;
        [SerializeField] private Color _lowHealthColor;
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _image;

        public void Set(float percent)
        {
            _slider.value = percent;
            
            Debug.Log(percent);
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