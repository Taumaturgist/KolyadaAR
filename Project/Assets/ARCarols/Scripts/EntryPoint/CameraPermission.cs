using UnityEngine;
using UnityEngine.Android;

public class CameraPermission : MonoBehaviour
{
    private bool _requestCamPerm;
    private bool _permissionAccess;
    
    private bool CheckCameraPermission()
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
                popup.ChangeHeader("Permission error");
                popup
                    .SetDescription("To continue, you need to provide access in your phone settings")
                    .HideCancelBtn()
                    .SetCallBacks(null, () =>
                    {
                        _permissionAccess = false;
                        Permission.RequestUserPermission(Permission.Camera);
                        popup.Hide();
                    })
                    .Show();
            }
            _requestCamPerm = true;
            return false;
        }
        
        return true;
    }
}
