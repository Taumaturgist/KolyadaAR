using UnityEngine;
using UnityEngine.UI;

namespace BurningKnight.PanelManager.Demo_3
{
    public class ViewADemo3 : ViewWithModelBase<PanelModel_A_Demo_3>
    {
        [SerializeField] private Button _openSettingsButton;

        public override PanelType PanelType         => PanelType.Screen;
        public override bool      RememberInHistory => true;

        protected override void OnInitialize()
        {
            _openSettingsButton.onClick.AddListener(OnClickSettings);
        }

        protected override void OnOpened() {}

        protected override void OnClosed() {}

        private void OnClickSettings()
        {
            Model.OpenSettings();
        }
    }
}