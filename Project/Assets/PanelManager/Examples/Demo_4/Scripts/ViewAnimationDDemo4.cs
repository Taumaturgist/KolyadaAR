using BurningKnight.PanelManager;
using PanelManager.PanelAnimations;
using UnityEngine;
using UnityEngine.UI;

namespace PanelManager.Examples.Demo_4.Scripts
{
    public class ViewAnimationDDemo4 : ViewAnimationBase
    {
        [SerializeField] private Button _buttonBack;
        [SerializeField] private Button _buttonOpenA;

        public override PanelType PanelType         => PanelType.Screen;
        public override bool RememberInHistory => true;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _buttonBack.onClick.AddListener(Back);
            _buttonOpenA.onClick.AddListener(OpenA);
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}

        private void OpenA()
        {
            _panelManager.OpenPanel<ViewAnimationADemo4>();
        }

        private void Back()
        {
            _panelManager.OpenPreviousPanel();
        }
    }
}