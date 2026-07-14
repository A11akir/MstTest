using System;
using UnityEngine;

namespace Onboarding.Onboarding.Runtime.Ads
{
    public abstract class AdServiceBehaviour : MonoBehaviour, IAdService
    {
        public abstract event Action<AdWatchResult> AdClosed;

        public abstract void PreloadAd();
        public abstract AdShowResult TryShowAd();
    }
}
