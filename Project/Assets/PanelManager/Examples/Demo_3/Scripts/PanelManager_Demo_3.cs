using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace BurningKnight.PanelManager.Demo_3
{
    public class PanelManager_Demo_3 : PanelManagerBase
    {
        [Header("Controllers")]
        [SerializeField] private SettingsController_Demo_3 _settingsController;

        private void Awake()
        {
            _settingsController = new SettingsController_Demo_3
            {
                MusicVolume = Random.Range(0, 100)
            };

            CreatePanelsFromSettings();

            OpenPanel<ViewADemo3>();
        }

        protected override void DefineModels(Dictionary<Type, PanelModelBase> map)
        {
            map.Add(typeof(ViewADemo3), new PanelModel_A_Demo_3());
            map.Add(typeof(ViewBDemo3), new PanelModel_B_Demo_3(_settingsController));
        }
    }
}