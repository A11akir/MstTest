using System;
using Onboarding.Onboarding.Runtime.Ads;
using UnityEngine;

namespace Onboarding.Onboarding.Runtime.UI
{
    public sealed class AdWindowsController : MonoBehaviour
    {
        private AdWindowView[] _windows;
        private bool _initialized;

        private void Awake() => EnsureInitialized();
        
        public void Show(AdAsset ad, float rewardDurationSeconds, Action<AdWatchResult> onClosed)
        {
            EnsureInitialized();

            AdWindowView window = FindWindow(ad.Variant);
            if (window == null)
            {
                return;
            }

            window.Show(ad, rewardDurationSeconds, onClosed);
        }

        private AdWindowView FindWindow(AdAspectVariant variant)
        {
            foreach (AdWindowView window in _windows)
            {
                if (window.Variant == variant)
                    return window;
            }

            return null;
        }

        private void EnsureInitialized()
        {
            if (_initialized)
                return;

            _initialized = true;
            
            _windows = GetComponentsInChildren<AdWindowView>(includeInactive: true);

            if (_windows.Length == 0)
            {
                return;
            }
            
            foreach (AdWindowView window in _windows)
                window.gameObject.SetActive(false);
        }
    }
}
