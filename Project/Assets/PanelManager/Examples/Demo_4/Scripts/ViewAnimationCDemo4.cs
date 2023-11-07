using BurningKnight.PanelManager;
using UnityEngine;
using UnityEngine.UI;

namespace PanelManager.Examples.Demo_4.Scripts
{
    public class ViewAnimationCDemo4 : ViewBase
    {
        [SerializeField] private Button _buttonBack;
        [SerializeField] private Button _buttonOpenD;

        public override PanelType PanelType         => PanelType.Screen;
        public override bool      RememberInHistory => true;

        protected override void OnInitialize()
        {
            _buttonBack.onClick.AddListener(Back);
            _buttonOpenD.onClick.AddListener(OpenD);
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}

        private void OpenD()
        {
            _panelManager.OpenPanel<ViewAnimationDDemo4>();
        }

        private void Back()
        {
            _panelManager.OpenPreviousPanel();
        }
    }
}