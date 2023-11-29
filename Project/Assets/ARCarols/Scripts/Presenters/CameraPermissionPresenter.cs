using ARCarols.Scripts.Models;
using ARCarols.Scripts.UI;
using ARCarols.Scripts.UI.Enum;
using ARCarols.Scripts.UI.Panels;
using Project.Scripts.Presenters.Base;
using UnityEngine;
using UnityEngine.Android;

namespace ARCarols.Scripts.Presenters
{
    public class CameraPermissionPresenter : PresenterBase<MonologueModel, CameraPermissionView>
    {
        private bool _requestCamPerm;
        private bool _permissionAccess;
        private MainPanelManager _mainPanelManager;
        private PermissionCallbacks _permissionCallbacks;

        public CameraPermissionPresenter(MonologueModel model, CameraPermissionView view, MainPanelManager mainPanelManager) : base(model, view)
        {
            _mainPanelManager = mainPanelManager;
            if (Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                _mainPanelManager.OpenPanel<MenuView>();
                return;
            }
            view.AddButtonListener(OnCloseView);
            _permissionCallbacks = new PermissionCallbacks();
            _permissionCallbacks.PermissionDenied += PermissionDenied;
            _permissionCallbacks.PermissionDeniedAndDontAskAgain += PermissionDeniedAndDontAskAgain;
            _permissionCallbacks.PermissionGranted += PermissionGranted;
            Permission.RequestUserPermission(Permission.Camera);
        }

        protected override void ViewOpened()
        {
            base.ViewOpened();
        }

        protected override void ViewClosed()
        {
            
            base.ViewClosed();
        }

        private void PermissionDenied(string permission)
        {
            Debug.Log("PermissionDenied");
            _mainPanelManager.OpenPanel<CameraPermissionView, PopupEnum>(PopupEnum.CameraNotificationFirst);
        }
        
        private void PermissionDeniedAndDontAskAgain(string permission)
        {
            Debug.Log("PermissionDeniedAndDontAskAgain");
            _mainPanelManager.OpenPanel<CameraPermissionView, PopupEnum>(PopupEnum.CameraNotificationSecond);
        }

        private void PermissionGranted(string permission)
        {
            _mainPanelManager.OpenPanel<MenuView>();
        }

        public bool CheckCameraPermission(PopupEnum popupEnum)
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                
                if (!_requestCamPerm)
                {
                    Permission.RequestUserPermission(Permission.Camera);
                }
                else if (!_permissionAccess)
                {
                    _permissionAccess = true;
                    
                    _mainPanelManager.OpenPanel<CameraPermissionView, PopupEnum>(popupEnum);
                }

                _requestCamPerm = true;
                return false;
            }

            return true;
        }

        private void OnCloseView()
        {
            _permissionAccess = false;
            Permission.RequestUserPermission(Permission.Camera);
        }
    }
}