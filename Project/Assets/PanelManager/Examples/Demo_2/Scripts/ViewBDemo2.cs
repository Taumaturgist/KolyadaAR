using UnityEngine;
using UnityEngine.UI;

namespace BurningKnight.PanelManager.Demo_2
{
    public class ViewBDemo2 : ViewBase, IAcceptArg<string>
    {
        [SerializeField] private Text   _txt;
        [SerializeField] private Button _button;
        [SerializeField] private Button _buttonBack;

        public override PanelType PanelType         => PanelType.Screen;
        public override bool      RememberInHistory => true;

        protected override void OnInitialize()
        {
            _button.onClick.AddListener(Next);
            _buttonBack.onClick.AddListener(Back);
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}

        public void AcceptArg(string arg)
        {
            _txt.text = $"Player name: {arg}";
        }

        private void Next()
        {
            var randomValue = Random.Range(100, 999);
            _panelManager.OpenPanel<ViewCDemo2, int>(randomValue);
        }

        private void Back()
        {
            _panelManager.OpenPreviousPanel();
        }
    }
}