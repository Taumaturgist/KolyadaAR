using Project.Scripts.Models.Base;
using UniRx;
using UnityEngine.Android;

namespace ARCarols.Scripts.Models
{
    public class CameraPermissionModel: ModelBase
    {

        public ReactiveCommand OnCameraRequest;
        
        private bool _requestCamPerm;
        private bool _permissionAccess;

        public CameraPermissionModel()
        {
            OnCameraRequest = new ReactiveCommand();
        }

        public void UpdateRequestCameraPermission()
        {
            _requestCamPerm = false;
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
                    
                    OnCameraRequest.Execute();
                }
                _requestCamPerm = true;
                return false;
            }
            
            return true;
        }
        
        public bool CheckCameraPermissionActive()
        {
                    
            if (Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                return true;
            }

            return false;
        }



    }
}