using Onboarding.Onboarding.Runtime.Ads;
using Onboarding.Onboarding.Runtime.UI;
using UnityEngine;

namespace Onboarding.Onboarding.Runtime.Bootstrap
{
    public sealed class PaywallBootstrapper : MonoBehaviour
    {
        [SerializeField] private PaywallView _view;
        [SerializeField] private AdServiceBehaviour _adService;

        private PaywallPresenter _presenter;

        private void Awake() => _presenter = new PaywallPresenter(_view, _adService);

        private void Start() => _adService.PreloadAd();

        private void OnDestroy() => _presenter?.Dispose();
    }
}
