using System;
using ARCarols.Scripts.Models;
using ARCarols.Scripts.Presenters;
using ARCarols.Scripts.UI;
using ARCarols.Scripts.UI.Configs;
using ARCarols.Scripts.UI.Panels;
using Screenshoter;
using UnityEngine;

namespace EntryPoint
{
    public class ApplicationEntryPoint : MonoBehaviour
    {
        [Header("Configs")]
        
        [SerializeField] private MenuItemsConfig _menuItemsConfig;

        [Header("Managers")]
        [SerializeField] private ScreenshotManager _screenshotManager;

        [SerializeField] private MainPanelManager _mainPanelManager;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            
            _mainPanelManager.Init();

            InitModule();
        }

        private void Start()
        {
            _mainPanelManager.OpenPanel<MenuView>();
        }

        private void InitModule()
        {
            InitMainMenuModule();
        }

        private void InitMainMenuModule()
        {
            var mainMenuModel = new MainMenuModel(_menuItemsConfig);

            var view = _mainPanelManager.SudoGetPanel<MenuView>();

            var mainMenuPresenter = new MainMenuPresenter(mainMenuModel, view);
        }
    }
}