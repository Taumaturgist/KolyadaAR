using UnityEngine;
using UnityEngine.UI;

namespace BurningKnight.PanelManager.Demo_2
{
    public class ViewADemo2 : ViewBase
    {
        [SerializeField] private Button     _button;
        [SerializeField] private InputField _input;

        public override PanelType PanelType         => PanelType.Screen;
        public override bool      RememberInHistory => true;

        protected override void OnInitialize()
        {
            _input.text = "Player";

            _button.onClick.AddListener(Next);
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}

        private void Next()
        {
            _panelManager.OpenPanel<ViewBDemo2, string>(_input.text);
        }
    }
}