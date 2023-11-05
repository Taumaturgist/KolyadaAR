using UnityEngine;
using UnityEngine.UI;

namespace BurningKnight.PanelManager.Demo_1
{
    public class ViewADemo1 : ViewBase
    {
        [SerializeField] private Button _button;

        public override PanelType PanelType         => PanelType.Screen;
        public override bool      RememberInHistory => true;

        protected override void OnInitialize()
        {
            _button.onClick.AddListener(ClickButton);
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}

        private void ClickButton()
        {
            _panelManager.OpenPanel<ViewBDemo1>();
        }
    }
}