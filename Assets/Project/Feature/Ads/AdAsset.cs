using UnityEngine;

namespace Onboarding.Onboarding.Runtime.Ads
{
    public sealed class AdAsset
    {
        public Texture2D Image { get; }
        public AdAspectVariant Variant { get; }
        public float Aspect => Image.width / (float)Image.height;

        public AdAsset(Texture2D image, AdAspectVariant variant)
        {
            Image = image;
            Variant = variant;
        }
    }
}
