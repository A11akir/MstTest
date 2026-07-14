using System;

namespace Onboarding.Onboarding.Runtime.Ads
{
    public enum AdAspectVariant
    {
        Tablet4x3,
        Desktop16x9,
        Phone9x21,
    }

    public static class AdAspectVariantExtensions
    {
        public static string FolderName(this AdAspectVariant variant) => variant switch
        {
            AdAspectVariant.Tablet4x3 => "4x3",
            AdAspectVariant.Desktop16x9 => "16x9",
            AdAspectVariant.Phone9x21 => "9x21",
            _ => throw new ArgumentOutOfRangeException(nameof(variant), variant, null),
        };
    }
}
