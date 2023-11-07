using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class InstantiateOnTap : MonoBehaviour
{
    [SerializeField] private GameObject prefabObject;

    private GameObject spawnedObject;
    private Vector2 touchPosition;
    private ARRaycastManager _arRaycastManager;
    private List<ARRaycastHit> hits = new();

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                touchPosition = touch.position;
            if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                if (spawnedObject == null)
                    spawnedObject = Instantiate(prefabObject, hitPose.position, hitPose.rotation);
                else
                {
                    spawnedObject.transform.position = hitPose.position;
                    spawnedObject.transform.LookAt(Camera.main.transform);
                }
                    
            }
        }
    }
}
