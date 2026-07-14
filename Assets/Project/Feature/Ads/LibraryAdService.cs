using System;
using System.Collections;
using Onboarding.Onboarding.Runtime.Configs;
using Onboarding.Onboarding.Runtime.UI;
using UnityEngine;

namespace Onboarding.Onboarding.Runtime.Ads
{
    [RequireComponent(typeof(AdWindowsController))]
    public sealed class LibraryAdService : AdServiceBehaviour
    {
        [SerializeField] private AdServiceConfig _cacheConfig;
        [SerializeField] private AdDisplayConfig _displayConfig;

        private AdWindowsController _windowsController;
        private AdLibrary _library;
        private AdAsset _selectedAd;
        private Coroutine _loadingRoutine;
        private bool _isAdReady;

        public override event Action<AdWatchResult> AdClosed;

        private void Awake()
        {
            _windowsController = GetComponent<AdWindowsController>();
            _library = new AdLibrary(_displayConfig.LibraryRootPath);
        }

        public override void PreloadAd()
        {
            if (_isAdReady || _loadingRoutine != null)
                return;

            if (!_library.TrySelectNext(out _selectedAd))
                return;

            _loadingRoutine = StartCoroutine(CachingRoutine());
        }

        public override AdShowResult TryShowAd()
        {
            if (!_isAdReady)
                return AdShowResult.NotLoaded;

            _isAdReady = false;
            _windowsController.Show(_selectedAd, _displayConfig.RewardDurationSeconds, OnAdWindowClosed);
            return AdShowResult.Shown;
        }

        private IEnumerator CachingRoutine()
        {
            yield return new WaitForSeconds(_cacheConfig.CacheDurationSeconds);

            _loadingRoutine = null;
            _isAdReady = true;
        }

        private void OnAdWindowClosed(AdWatchResult result)
        {
            _selectedAd = null;
            AdClosed?.Invoke(result);
            PreloadAd();
        }
    }
}
