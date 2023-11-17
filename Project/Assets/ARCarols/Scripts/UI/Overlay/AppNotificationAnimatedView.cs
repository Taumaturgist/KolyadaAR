using ARCarols.Scripts.UI.Configs;
using ARCarols.Scripts.UI.Enum;
using DG.Tweening;
using PanelManager.Scripts.Interfaces;
using PanelManager.Scripts.Panels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Overlay
{
    public class AppNotificationAnimatedView : ViewBase, IAcceptArg<PopupEnum>
    {
        [SerializeField] private PopupTextConfig _popupTextConfig;

        [SerializeField] private Button _buttonSkip;
        [SerializeField] private TMP_Text _notificationText;
        [SerializeField] private Image _backgroundText;

        [SerializeField] private float _animationDuration = 1;
        [SerializeField] private float _delay = 0.5f;
        
        public override PanelType PanelType => PanelType.Overlay;
        public override bool RememberInHistory => false;
        
        private Sequence _sequence;

        private Color _defaultNotificationText;
        private Color _defaultColorBackgroundText;

        protected override void OnInitialize()
        {
            _buttonSkip.onClick.AddListener(OnAnimationComplete);
        }
        
        protected override void OnOpened()
        {
            base.OnOpened();

            StartAnimation();
        }

        private void StartAnimation()
        {
            _sequence = DOTween.Sequence();
            
            _defaultColorBackgroundText = _backgroundText.color;
            
            _defaultNotificationText = _notificationText.color;
            
            _sequence.SetDelay(_delay)
                     .Append(_backgroundText.DOFade(0, _animationDuration))
                     .Join(_notificationText.DOFade(0, _animationDuration))
                     .onComplete += OnAnimationComplete;
        }

        private void OnAnimationComplete()
        {
            _sequence?.Kill();
            
            _backgroundText.color = _defaultColorBackgroundText;
            
            _notificationText.color = _defaultNotificationText;
            
            Close();

        }

        public void AcceptArg(PopupEnum arg)
        {
            _notificationText.text = _popupTextConfig.GetText(arg);
        }
    }
}