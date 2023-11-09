using UnityEngine;
using UnityEngine.XR.ARFoundation;


namespace Ar
{
    public class ArFaceTrackingManager : MonoBehaviour
    {
        [SerializeField] private ARFaceManager _arFaceManager;

        [SerializeField] private GameObject _origin;

        public void ChangeMask(GameObject maskPrefab = null)
        {
            ClearMask();

            _arFaceManager = _origin.AddComponent<ARFaceManager>();
            
            _arFaceManager.facePrefab =maskPrefab == null ? null: maskPrefab;
        }
        
        public void ChangeSelfie(GameObject selfiePrefab = null)
        {
            ClearMask();

            _arFaceManager = _origin.AddComponent<ARFaceManager>();
            
            _arFaceManager.facePrefab = selfiePrefab == null ? null: selfiePrefab;
        }

        private void ClearMask()
        {
            foreach (var trackable in _arFaceManager.trackables)
            {
                DestroyImmediate(trackable.gameObject);
            }
            DestroyImmediate(_arFaceManager);
        }
        
    }
}

