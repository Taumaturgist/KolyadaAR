using UnityEngine;
using UnityEngine.UI;

namespace BurningKnight.PanelManager.Demo_2
{
    public class ViewCDemo2 : ViewBase, IAcceptArg<int>
    {
        [SerializeField] private Text   _txt;
        [SerializeField] private Button _buttonClose;
        [SerializeField] private Button _buttonNext;

        public override PanelType PanelType         => PanelType.Overlay;
        public override bool      RememberInHistory => false;

        protected override void OnInitialize()
        {
            _buttonClose.onClick.AddListener(Close);
            _buttonNext.onClick.AddListener(Next);
        }

        private void Next()
        {
            _panelManager.OpenPanel<ViewDDemo2>();
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}

        public void AcceptArg(int arg)
        {
            _txt.text = $"Random message: {arg}";
        }
    }
}