using UnityEngine;

namespace Onboarding.Onboarding.Runtime.Configs
{
    [CreateAssetMenu(fileName = "AdServiceConfig", menuName = "Onboarding/Ad Service Config")]
    public sealed class AdServiceConfig : ScriptableObject
    {
        [SerializeField, Min(0f)]
        [Tooltip("Имитация длительности кэширования рекламы, сек (по ТЗ 3-5 сек).")]
        private float _cacheDurationSeconds = 4f;

        public float CacheDurationSeconds => _cacheDurationSeconds;
    }
}
