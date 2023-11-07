using UnityEngine;
using UnityEngine.UI;

namespace BurningKnight.PanelManager.Demo_1
{
    public class ViewEDemo1 : ViewBase
    {
        [SerializeField] private Button _buttonClose;

        public override PanelType PanelType         => PanelType.Overlay;
        public override bool      RememberInHistory => false;

        protected override void OnInitialize()
        {
            _buttonClose.onClick.AddListener(Close);
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}
    }
}