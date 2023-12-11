using System.Collections;
using Ar;
using ARCarols.Scripts.Character;
using ARCarols.Scripts.Character.Config;
using ARCarols.Scripts.Masks;
using ARCarols.Scripts.Models;
using ARCarols.Scripts.Presenters;
using ARCarols.Scripts.UI;
using ARCarols.Scripts.UI.Configs;
using ARCarols.Scripts.UI.Overlay;
using ARCarols.Scripts.UI.Panels;
using Screenshoter;
using UnityEngine;
using UnityEngine.Android;

namespace EntryPoint
{
    public class ApplicationEntryPoint : MonoBehaviour
    {
        [Header("Configs")]
        
        [SerializeField] private MenuItemsConfig _menuItemsConfig;

        [SerializeField] private MaskListConfig _maskListConfig;

        [SerializeField] private PopupTextConfig _popupTextConfig;

        [SerializeField] private CharacterTextConfig _kolyadaSongsConfig;
        

        [Header("Managers")]
        [SerializeField] private ScreenshotManager _screenshotManager;

        [SerializeField] private MainPanelManager _mainPanelManager;

        [SerializeField] private ArManager _arManager;

        private CurrentCharacterContainer _characterContainer;

        private CameraPermissionModel _cameraPermissionModel;

        private void Awake()
        {
            Application.targetFrameRate = 60;

            _characterContainer = new CurrentCharacterContainer();
            
            InitConfig();
            
            InitManager();

            InitModule();
        }

        private IEnumerator Start()
        {
            Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            
            _mainPanelManager.OpenPanel<MenuView>();

            while (_cameraPermissionModel.CheckCameraPermission() == false)
            {
                yield return null;
            }
            
            _arManager.gameObject.SetActive(true);
        }

        private void InitManager()
        {
            _screenshotManager.Init(_mainPanelManager);
        }
        
        private void InitConfig()
        {
            _mainPanelManager.Init();
            
            _popupTextConfig.Init();
        }
        
        private void InitModule()
        {
            InitCameraPermissionModule();
            
            InitMonologueModule();

            InitMainMenuModule();

            InitCharacterActionsModule();

            InitMaskModule();

            InitSelfieModule();

            InitKolyadaActionModule();
        }

        private void InitMainMenuModule()
        {
            
            var panelForCompleteMonologueCharacter = _mainPanelManager.SudoGetPanel<CharacterActionsView>();
            
            var mainMenuModel = new MainMenuModel(_menuItemsConfig, _characterContainer, _arManager, panelForCompleteMonologueCharacter);

            var view = _mainPanelManager.SudoGetPanel<MenuView>();

            var mainMenuPresenter = new MainMenuPresenter(mainMenuModel, view);
        }
        
        private void InitCameraPermissionModule()
        {
             _cameraPermissionModel = new CameraPermissionModel();
            
            var view = _mainPanelManager.SudoGetPanel<CameraPermissionView>();

            var cameraPermissionPresenter = new CameraPermissionPresenter(_cameraPermissionModel, view);
            
        }

        private void InitMonologueModule()
        { 
            var monologueModel = new MonologueModel(_characterContainer, _arManager, _mainPanelManager);
            
            var view = _mainPanelManager.SudoGetPanel<CharacterMonologueView>();

            var monologuePresenter = new MonologuePresenter(monologueModel, view);
        }

        private void InitCharacterActionsModule()
        {
            var characterActionsModel = new CharacterActionsModel(_arManager, _characterContainer);

            var view = _mainPanelManager.SudoGetPanel<CharacterActionsView>();

            var characterActionsPresenter = new CharacterActionsPresenter(characterActionsModel, view);
        }

        private void InitMaskModule()
        {
            var maskModel = new MaskModel(_arManager, _screenshotManager, _maskListConfig);

            var view = _mainPanelManager.SudoGetPanel<MaskView>();

            var maskPresenter = new MaskPresenter(maskModel, view);
        }

        private void InitSelfieModule()
        {
            var selfieModel = new SelfieModel(_arManager, _screenshotManager, _characterContainer);

            var view = _mainPanelManager.SudoGetPanel<SelfieView>();

            var selfiePresenter = new SelfiePresenters(selfieModel, view);
        }

        private void InitKolyadaActionModule()
        {
            var kolyadaActionModel = new KolyadaActionModel(_kolyadaSongsConfig, _arManager);
            
            var view = _mainPanelManager.SudoGetPanel<GrandfatherKolyadaActionView>();

            var kolyadaActionPresenter = new KolyadaActionPresenter(kolyadaActionModel, view);
        }
    }
}