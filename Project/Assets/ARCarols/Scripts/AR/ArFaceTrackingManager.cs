using UnityEngine;
using UnityEngine.XR.ARFoundation;


namespace Ar
{
    public class ArFaceTrackingManager : MonoBehaviour
    {
        [SerializeField] private ARFaceManager _arFaceManager;

        [SerializeField] private GameObject _origin;

        public void ChangeMask(MaskData maskData = null)
        {
            ClearMask();

            _arFaceManager = _origin.AddComponent<ARFaceManager>();
            
            _arFaceManager.facePrefab =maskData == null ? null: maskData.Prefab;
        }
        
        public void ChangeSelfie(GameObject character = null)
        {
            ClearMask();

            _arFaceManager = _origin.AddComponent<ARFaceManager>();
            
            _arFaceManager.facePrefab = character == null ? null: character;
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

