using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Onboarding.Onboarding.Runtime.Ads
{
    public sealed class AdLibrary
    {
        private readonly List<AdAsset> _ads = new();
        private int _lastSelectedIndex = -1;

        public AdLibrary(string resourcesRootPath)
        {
            foreach (AdAspectVariant variant in Enum.GetValues(typeof(AdAspectVariant)))
            {
                string folder = $"{resourcesRootPath}/{variant.FolderName()}";
                _ads.AddRange(Resources.LoadAll<Texture2D>(folder).Select(image => new AdAsset(image, variant)));
            }

            if (_ads.Count == 0)
            {
                Debug.LogWarning(
                    $"Библиотека рекламы пуста: положите картинки (Texture2D) в подпапки " +
                    $"Assets/Resources/{resourcesRootPath}/ (4x3, 16x9, 9x21)");
            }
        }
        
        public bool TrySelectNext(out AdAsset ad)
        {
            if (_ads.Count == 0)
            {
                ad = null;
                return false;
            }

            int index = Random.Range(0, _ads.Count);
            
            if (_ads.Count > 1 && index == _lastSelectedIndex)
                index = (index + 1) % _ads.Count;

            _lastSelectedIndex = index;
            ad = _ads[index];
            return true;
        }
    }
}
