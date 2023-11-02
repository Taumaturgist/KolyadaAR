using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArFaceTrackingManager : MonoBehaviour
{
    [SerializeField] private ARFaceManager _arFaceManager;

    public void ChangeMask(MaskData maskData)
    {
        foreach (var trackable in _arFaceManager.trackables)
        {
            DestroyImmediate(trackable.gameObject);
        }
        DestroyImmediate(_arFaceManager);

        _arFaceManager = gameObject.AddComponent<ARFaceManager>();
        _arFaceManager.facePrefab = maskData.Prefab;
    }

    public void EnableMask()
    {
        foreach (var trackable in _arFaceManager.trackables)
        {
            DestroyImmediate(trackable.gameObject);
        }
        DestroyImmediate(_arFaceManager);
        
        _arFaceManager = gameObject.AddComponent<ARFaceManager>();
        _arFaceManager.facePrefab = null;
    }
}