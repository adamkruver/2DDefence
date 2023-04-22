using System;
using System.Collections;
using UnityEngine;

namespace Sources.Common.Presentatin
{
    public class Curtain : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeSpeed = 1f;

        private Coroutine _fadeJob;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Show()
        {
            _canvas.gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            StartFade(0);
        }

        private void StartFade(float alpha)
        {
            StopFade();

            _fadeJob = StartCoroutine(FadeCoroutine(alpha));
        }

        private void StopFade()
        {
            if (_fadeJob == null)
                return;
            
            StopCoroutine(_fadeJob);
        }

        private IEnumerator FadeCoroutine(float alpha)
        {
            while (Math.Abs(_canvasGroup.alpha - alpha) > float.Epsilon)
            {
                _canvasGroup.alpha = Mathf.MoveTowards(_canvasGroup.alpha, alpha, _fadeSpeed * Time.deltaTime);
                yield return null;
            }
            
            _canvas.gameObject.SetActive(false);
        }
    }
}