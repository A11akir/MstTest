using System;

namespace Onboarding.Onboarding.Runtime.Ads
{
    public interface IAdService
    {
        event Action<AdWatchResult> AdClosed;
        void PreloadAd();
        AdShowResult TryShowAd();
    }
}
