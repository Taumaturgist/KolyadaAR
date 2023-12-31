using ARCarols.Scripts.UI.Configs;
using ARCarols.Scripts.UI.Enum;
using DG.Tweening;
using PanelManager.Scripts.Interfaces;
using PanelManager.Scripts.Panels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArNotificationView : ViewBase, IAcceptArg<PopupEnum>
{
    [SerializeField] private PopupTextConfig _popupTextConfig;
    
    [SerializeField] private TMP_Text _notificationText;
    [SerializeField] private Image _backgroundText;

    [SerializeField] private float _animationDuration = 1;
    [SerializeField] private float _delay = 0.5f;
        
    public override PanelType PanelType => PanelType.Overlay;
    public override bool RememberInHistory => false;
        
    private Sequence _sequence;

    private Color _defaultNotificationText;
    private Color _defaultColorBackgroundText;
    
        
    protected override void OnOpened()
    {
        base.OnOpened();

        StartAnimation();
    }

    protected override void OnClosed()
    {
        base.OnClosed();
        
        AnimationComplete();
    }

    private void StartAnimation()
    {
        _sequence = DOTween.Sequence();
            
        _defaultColorBackgroundText = _backgroundText.color;
            
        _defaultNotificationText = _notificationText.color;
            
        // _sequence.SetDelay(_delay)
        //     .Append(_backgroundText.DOFade(0, _animationDuration))
        //     .Join(_notificationText.DOFade(0, _animationDuration));
    }

    private void AnimationComplete()
    {
        _sequence?.Kill();
            
        _backgroundText.color = _defaultColorBackgroundText;
            
        _notificationText.color = _defaultNotificationText;
    }

    public void AcceptArg(PopupEnum arg)
    {
        _notificationText.text = _popupTextConfig.GetText(arg);
    }
}
