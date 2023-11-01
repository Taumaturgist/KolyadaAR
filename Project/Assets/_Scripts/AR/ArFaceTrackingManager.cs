using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Random = UnityEngine.Random;

public class ArFaceTrackingManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _maskPrefabs;

    [SerializeField] private ARFaceManager _arFaceManager;
    
    public void ChangeMask()
    {
        foreach (var trackable in _arFaceManager.trackables)
        {
            DestroyImmediate(trackable.gameObject);
        }
        DestroyImmediate(_arFaceManager);

        _arFaceManager = gameObject.AddComponent<ARFaceManager>();
        _arFaceManager.facePrefab = _maskPrefabs[Random.Range(0, _maskPrefabs.Length)];
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