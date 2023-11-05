using UnityEngine;

namespace BurningKnight.PanelManager.Demo_3
{
    public class PanelModel_B_Demo_3 : PanelModelBase
    {
        public readonly ReactiveProperty<int> MusicVolume;
        
        private readonly SettingsController_Demo_3 _settingsController;

        public PanelModel_B_Demo_3(SettingsController_Demo_3 settingsController)
        {
            _settingsController = settingsController;

            MusicVolume = _settingsController.MusicVolume;
        }

        protected override void OnInitialize() {}

        public override void OnPanelOpened()
        {
            MusicVolume.Subscribe(this, OnValueChanged);
        }

        public override void OnPanelClosed()
        {
            MusicVolume.Unsubscribe(this, OnValueChanged);
        }

        public void OnValueChanged(int value)
        {
            _settingsController.MusicVolume = value;
        }

        public void Back()
        {
            _panelManager.OpenPreviousPanel();
        }
    }
}