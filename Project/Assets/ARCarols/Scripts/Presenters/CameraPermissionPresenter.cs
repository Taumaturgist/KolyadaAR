using ARCarols.Scripts.Models;
using ARCarols.Scripts.UI;
using ARCarols.Scripts.UI.Enum;
using ARCarols.Scripts.UI.Panels;
using Project.Scripts.Presenters.Base;
using UnityEngine.Android;

namespace ARCarols.Scripts.Presenters
{
    public class CameraPermissionPresenter : PresenterBase<MonologueModel, CameraPermissionView>
    {
        private bool _requestCamPerm;
        private bool _permissionAccess;
        private MainPanelManager _mainPanelManager;

        public CameraPermissionPresenter(MonologueModel model, CameraPermissionView view, MainPanelManager mainPanelManager) : base(model, view)
        {
            _mainPanelManager = mainPanelManager;
            if (Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                _mainPanelManager.OpenPanel<MenuView>();
                return;
            }
            view.AddButtonListener(OnCloseView);
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

        public bool CheckCameraPermission()
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                if (!_requestCamPerm)
                {
                    Permission.RequestUserPermission(Permission.Camera);
                }
                else if(!_permissionAccess)
                {
                    _permissionAccess = true;
                    _mainPanelManager.OpenPanel<CameraPermissionView, PopupEnum>(PopupEnum.CameraNotificationSecond);
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
            _view.Close();
        }
    }
}