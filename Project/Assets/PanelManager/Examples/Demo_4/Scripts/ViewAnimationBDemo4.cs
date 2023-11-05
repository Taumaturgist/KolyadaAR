using BurningKnight.PanelManager;
using PanelManager.PanelAnimations;
using UnityEngine;
using UnityEngine.UI;

namespace PanelManager.Examples.Demo_4.Scripts
{
    public class ViewAnimationBDemo4 : ViewAnimationBase
    {
        [SerializeField] private Button _buttonBack;

        [SerializeField] private Button _buttonOpenC;
        [SerializeField] private Button _buttonOpenD;
        [SerializeField] private Button _buttonOpenE;

        public override PanelType PanelType         => PanelType.Screen;
        public override bool      RememberInHistory => true;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _buttonBack.onClick.AddListener(Back);
            _buttonOpenC.onClick.AddListener(OpenC);
            _buttonOpenD.onClick.AddListener(OpenD);
            _buttonOpenE.onClick.AddListener(OpenE);
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}

        private void OpenC()
        {
            _panelManager.OpenPanel<ViewAnimationCDemo4>();
        }

        private void OpenD()
        {
            _panelManager.OpenPanel<ViewAnimationDDemo4>();
        }

        private void OpenE()
        {
            _panelManager.OpenPanel<ViewAnimationEDemo4>();
        }

        private void Back()
        {
            _panelManager.OpenPreviousPanel();
        }
    }
}