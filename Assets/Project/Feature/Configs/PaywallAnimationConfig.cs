using UnityEngine;

namespace Onboarding.Onboarding.Runtime.Configs
{
    [CreateAssetMenu(fileName = "PaywallAnimationConfig", menuName = "Onboarding/Paywall Animation Config")]
    public sealed class PaywallAnimationConfig : ScriptableObject
    {
        [Header("Появление экрана")]
        [SerializeField, Min(0f)]
        [Tooltip("Длительность плавного проявления UI (альфа 0 -> 1), сек.")]
        private float _fadeInDuration = 0.8f;

        [Header("Пульсация кнопки")]
        [SerializeField, Min(0.1f)]
        [Tooltip("Период одного полного цикла пульсации, сек.")]
        private float _pulsePeriodSeconds = 1.2f;

        [SerializeField, Range(0f, 0.5f)]
        [Tooltip("Амплитуда пульсации: 0.06 = масштаб колеблется от 1.0 до 1.06.")]
        private float _pulseAmplitude = 0.06f;

        public float FadeInDuration => _fadeInDuration;
        public float PulsePeriodSeconds => _pulsePeriodSeconds;
        public float PulseAmplitude => _pulseAmplitude;
    }
}
