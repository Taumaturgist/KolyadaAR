using UnityEngine;
using UnityEngine.UI;

namespace BurningKnight.PanelManager.Demo_1
{
    public class ViewDDemo1 : ViewBase
    {
        [SerializeField] private Button _buttonBack;
        [SerializeField] private Button _buttonOpenA;

        public override PanelType PanelType         => PanelType.Screen;
        public override bool      RememberInHistory { get; }

        protected override void OnInitialize()
        {
            _buttonBack.onClick.AddListener(Back);
            _buttonOpenA.onClick.AddListener(OpenA);
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}

        private void OpenA()
        {
            _panelManager.OpenPanel<ViewADemo1>();
        }

        private void Back()
        {
            _panelManager.OpenPreviousPanel();
        }
    }
}