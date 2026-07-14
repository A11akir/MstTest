using System.Collections;
using Onboarding.Onboarding.Runtime.Configs;
using UnityEngine;

namespace Onboarding.Onboarding.Runtime.Animations
{
    public sealed class ScalePulseAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private PaywallAnimationConfig _config;

        private Vector3 _baseScale;

        private void OnEnable()
        {
            _baseScale = _target.localScale;

            StartCoroutine(PulseRoutine());
        }

        private void OnDisable() => _target.localScale = _baseScale;

        private IEnumerator PulseRoutine()
        {
            for (float time = 0f; ; time += Time.deltaTime)
            {
                float wave = (Mathf.Sin(time * 2f * Mathf.PI / _config.PulsePeriodSeconds) + 1f) * 0.5f;
                _target.localScale = _baseScale * (1f + _config.PulseAmplitude * wave);

                yield return null;
            }
        }
    }
}
