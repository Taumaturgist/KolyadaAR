using Ar;
using ARCarols.Scripts.Character;
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

        [SerializeField] private ArManager _arManager;

        private CurrentCharacterContainer _characterContainer; 

        private void Awake()
        {
            Application.targetFrameRate = 60;

            _characterContainer = new CurrentCharacterContainer();
            
            _mainPanelManager.Init();

            InitModule();
        }

        private void Start()
        {
            _mainPanelManager.OpenPanel<MenuView>();
        }

        private void InitModule()
        {
            InitMonologueModule();
            
            InitMainMenuModule();
        }

        private void InitMainMenuModule()
        {
            var mainMenuModel = new MainMenuModel(_menuItemsConfig, _characterContainer, _arManager);

            var view = _mainPanelManager.SudoGetPanel<MenuView>();

            var mainMenuPresenter = new MainMenuPresenter(mainMenuModel, view);
        }

        private void InitMonologueModule()
        { 
            var monologueModel = new MonologueModel(_characterContainer, _arManager);
            
            var view = _mainPanelManager.SudoGetPanel<CharacterMonologueView>();

            var monologuePresenter = new MonologuePresenter(monologueModel, view);
        }
    }
}