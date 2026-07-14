using UnityEngine;

namespace Onboarding.Onboarding.Runtime.Configs
{
    [CreateAssetMenu(fileName = "AdDisplayConfig", menuName = "Onboarding/Ad Display Config")]
    public sealed class AdDisplayConfig : ScriptableObject
    {
        [SerializeField, Min(0f)]
        [Tooltip("Микро-таймер: сколько секунд нужно смотреть рекламу, чтобы просмотр засчитался.")]
        private float _rewardDurationSeconds = 5f;

        [SerializeField]
        [Tooltip("Корневая папка библиотеки рекламы внутри Resources. " +
                 "Внутри — подпапки по форм-факторам: 4x3, 16x9, 9x21.")]
        private string _libraryRootPath = "AdsLibrary";

        public float RewardDurationSeconds => _rewardDurationSeconds;
        public string LibraryRootPath => _libraryRootPath;
    }
}
