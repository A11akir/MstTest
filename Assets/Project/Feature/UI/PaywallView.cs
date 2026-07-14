using System;
using UnityEngine;
using UnityEngine.UI;

namespace Onboarding.Onboarding.Runtime.UI
{
    public sealed class PaywallView : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        
        public event Action ContinueClicked;

        private void OnEnable() => _continueButton.onClick.AddListener(OnContinueButtonClicked);

        private void OnDisable() => _continueButton.onClick.RemoveListener(OnContinueButtonClicked);

        private void OnContinueButtonClicked() => ContinueClicked?.Invoke();
    }
}
