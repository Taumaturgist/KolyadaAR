using Project.Scripts.Models.Base;
using UniRx;
using UnityEngine.Android;

namespace ARCarols.Scripts.Models
{
    public class CameraPermissionModel : ModelBase
    {
        public ReactiveCommand OnCameraRequest;

        private bool _viewOpened;
        private bool _permissionAccess;

        public CameraPermissionModel()
        {
            OnCameraRequest = new ReactiveCommand();
        }

        public void UpdateRequestCameraPermission()
        {
            _viewOpened = false;
            Permission.RequestUserPermission("LAUNCH_CAPTURE_CONTENT_ACTIVITY_FOR_NOTE");
        }


        // public bool CheckCameraPermission()
        // {
        //     if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        //     {
        //         if (!_requestCamPerm)
        //         {
        //             Permission.RequestUserPermission(Permission.Camera);
        //         }
        //         else if(!_permissionAccess)
        //         {
        //             _permissionAccess = true;
        //             
        //             OnCameraRequest.Execute();
        //         }
        //         _requestCamPerm = true;
        //         return false;
        //     }
        //     
        //     return true;
        // }

        public bool CheckCameraPermission()
        {
            if (Permission.HasUserAuthorizedPermission("LAUNCH_CAPTURE_CONTENT_ACTIVITY_FOR_NOTE") == false)
            {
                if (_viewOpened == false)
                {
                    _viewOpened = true;

                    OnCameraRequest.Execute();
                }

                return false;
            }

            return true;
        }
    }
}