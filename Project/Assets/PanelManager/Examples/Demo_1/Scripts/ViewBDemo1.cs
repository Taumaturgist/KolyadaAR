using UnityEngine;
using UnityEngine.UI;

namespace BurningKnight.PanelManager.Demo_1
{
    public class ViewBDemo1 : ViewBase
    {
        [SerializeField] private Button _buttonBack;

        [SerializeField] private Button _buttonOpenC;
        [SerializeField] private Button _buttonOpenD;
        [SerializeField] private Button _buttonOpenE;

        public override PanelType PanelType         => PanelType.Screen;
        public override bool      RememberInHistory => true;

        protected override void OnInitialize()
        {
            _buttonBack.onClick.AddListener(Back);
            _buttonOpenC.onClick.AddListener(OpenC);
            _buttonOpenD.onClick.AddListener(OpenD);
            _buttonOpenE.onClick.AddListener(OpenE);
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}

        private void OpenC()
        {
            _panelManager.OpenPanel<ViewCDemo1>();
        }

        private void OpenD()
        {
            _panelManager.OpenPanel<ViewDDemo1>();
        }

        private void OpenE()
        {
            _panelManager.OpenPanel<ViewEDemo1>();
        }

        private void Back()
        {
            _panelManager.OpenPreviousPanel();
        }
    }
}