using System;
using Onboarding.Onboarding.Runtime.Ads;
using UnityEngine;

namespace Onboarding.Onboarding.Runtime.UI
{
    public sealed class PaywallPresenter : IDisposable
    {
        private const string AdStillLoadingMessage = "Реклама еще загружается...";
        private const string AdShownMessage = "Реклама успешно показана";
        private const string AdWatchedMessage = "Реклама успешно просмотрена";
        private const string AdClosedEarlyMessage = "Реклама досрочно закрыта";

        private readonly PaywallView _view;
        private readonly IAdService _adService;

        public PaywallPresenter(PaywallView view, IAdService adService)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _adService = adService ?? throw new ArgumentNullException(nameof(adService));

            _view.ContinueClicked += OnContinueClicked;
            _adService.AdClosed += OnAdClosed;
        }

        public void Dispose()
        {
            _view.ContinueClicked -= OnContinueClicked;
            _adService.AdClosed -= OnAdClosed;
        }

        private void OnContinueClicked()
        {
            switch (_adService.TryShowAd())
            {
                case AdShowResult.Shown:
                    Debug.Log(AdShownMessage);
                    break;

                case AdShowResult.NotLoaded:
                    Debug.Log(AdStillLoadingMessage);
                    break;
            }
        }

        private void OnAdClosed(AdWatchResult result) =>
            Debug.Log(result == AdWatchResult.Watched ? AdWatchedMessage : AdClosedEarlyMessage);
    }
}
