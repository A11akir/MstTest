using System;
using System.Collections;
using Onboarding.Onboarding.Runtime.Ads;
using UnityEngine;
using UnityEngine.UI;

namespace Onboarding.Onboarding.Runtime.UI
{
    public sealed class AdWindowView : MonoBehaviour
    {
        private const string CloseGlyph = "X";
        private const string CountdownFormat = "X ({0})";

        [SerializeField] private AdAspectVariant _variant;

        private RawImage _adSurface;
        private AspectRatioFitter _adAspectFitter;
        private Button _closeButton;
        private Text _closeButtonLabel;

        private Action<AdWatchResult> _onClosed;
        private bool _rewardEarned;
        
        public AdAspectVariant Variant => _variant;

        private void Awake()
        {
            _adSurface = GetComponentInChildren<RawImage>(true);
            _adAspectFitter = _adSurface.GetComponent<AspectRatioFitter>();
            _closeButton = GetComponentInChildren<Button>(true);
            _closeButtonLabel = _closeButton.GetComponentInChildren<Text>(true);
        }

        private void OnEnable() => _closeButton.onClick.AddListener(OnCloseClicked);

        private void OnDisable() => _closeButton.onClick.RemoveListener(OnCloseClicked);
        
        public void Show(AdAsset ad, float rewardDurationSeconds, Action<AdWatchResult> onClosed)
        {
            gameObject.SetActive(true);

            _onClosed = onClosed;
            _rewardEarned = false;

            _adSurface.texture = ad.Image;

            _adAspectFitter.aspectRatio = ad.Aspect;

            StartCoroutine(RewardTimerRoutine(rewardDurationSeconds));
        }

        private IEnumerator RewardTimerRoutine(float duration)
        {
            for (float remaining = duration; remaining > 0f; remaining -= Time.deltaTime)
            {
                _closeButtonLabel.text = string.Format(CountdownFormat, Mathf.CeilToInt(remaining));
                yield return null;
            }

            _rewardEarned = true;
            _closeButtonLabel.text = CloseGlyph;
        }

        private void OnCloseClicked()
        {
            AdWatchResult result = _rewardEarned ? AdWatchResult.Watched : AdWatchResult.ClosedEarly;

            _adSurface.texture = null;
            gameObject.SetActive(false);

            Action<AdWatchResult> onClosed = _onClosed;
            _onClosed = null;
            onClosed?.Invoke(result);
        }
    }
}
