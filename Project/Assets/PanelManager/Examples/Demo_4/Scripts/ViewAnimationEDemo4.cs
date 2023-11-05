using BurningKnight.PanelManager;
using PanelManager.PanelAnimations;
using UnityEngine;
using UnityEngine.UI;

namespace PanelManager.Examples.Demo_4.Scripts
{
    public class ViewAnimationEDemo4 : ViewAnimationBase
    {
        [SerializeField] private Button _buttonClose;

        public override PanelType PanelType         => PanelType.Overlay;
        public override bool      RememberInHistory => false;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _buttonClose.onClick.AddListener(() => _panelManager.ClosePanel<ViewAnimationEDemo4>());
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}
    }
}