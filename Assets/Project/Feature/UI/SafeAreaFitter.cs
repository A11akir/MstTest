using UnityEngine;

namespace Onboarding.Onboarding.Runtime.UI
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class SafeAreaFitter : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Rect _appliedSafeArea;

        private void Awake()
        {
            _rectTransform = (RectTransform)transform;
            ApplySafeArea();
        }

        private void Update()
        {
            if (_appliedSafeArea != Screen.safeArea)
                ApplySafeArea();
        }

        private void ApplySafeArea()
        {
            Rect safeArea = Screen.safeArea;
            var screenSize = new Vector2(Screen.width, Screen.height);
            
            _rectTransform.anchorMin = safeArea.position / screenSize;
            _rectTransform.anchorMax = (safeArea.position + safeArea.size) / screenSize;
            _rectTransform.offsetMin = Vector2.zero;
            _rectTransform.offsetMax = Vector2.zero;

            _appliedSafeArea = safeArea;
        }
    }
}
