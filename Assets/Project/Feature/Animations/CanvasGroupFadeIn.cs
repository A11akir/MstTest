using System.Collections;
using Onboarding.Onboarding.Runtime.Configs;
using UnityEngine;

namespace Onboarding.Onboarding.Runtime.Animations
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class CanvasGroupFadeIn : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private PaywallAnimationConfig _config;

        private void Awake() => _canvasGroup.alpha = 0f;

        private void Start() => StartCoroutine(FadeInRoutine());

        private IEnumerator FadeInRoutine()
        {
            float duration = _config.FadeInDuration;

            for (float elapsed = 0f; elapsed < duration; elapsed += Time.deltaTime)
            {
                _canvasGroup.alpha = Mathf.SmoothStep(0f, 1f, elapsed / duration);
                yield return null;
            }

            _canvasGroup.alpha = 1f;
        }
    }
}
