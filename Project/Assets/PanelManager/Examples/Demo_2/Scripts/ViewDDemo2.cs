using UnityEngine;
using UnityEngine.UI;

namespace BurningKnight.PanelManager.Demo_2
{
    public class ViewDDemo2 : ViewBase
    {
        [SerializeField] private Button _button;

        public override PanelType PanelType         => PanelType.Overlay;
        public override bool      RememberInHistory => false;

        protected override void OnInitialize()
        {
            _button.onClick.AddListener(Close);
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}
    }
}