using BurningKnight.PanelManager;
using PanelManager.PanelAnimations;
using UnityEngine;
using UnityEngine.UI;

namespace PanelManager.Examples.Demo_4.Scripts
{
    public class ViewAnimationADemo4 : ViewAnimationBase
    {
        [SerializeField] private Button _button;

        public override PanelType PanelType         => PanelType.Screen;
        public override bool      RememberInHistory => true;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _button.onClick.AddListener(ClickButton);
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}

        private void ClickButton()
        {
            _panelManager.OpenPanel<ViewAnimationBDemo4>();
        }
    }
}