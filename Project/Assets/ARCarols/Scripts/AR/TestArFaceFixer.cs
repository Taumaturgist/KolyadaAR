using UnityEngine;

public class TestArFaceFixer : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _occlusion;
    [SerializeField] private Transform _image;
    
    
    private void Start()
    {
        transform.SetParent(null, true);
    }

    private void FixedUpdate()
    {
        _image.transform.position = _parent.position;
            //_image.transform.eulerAngles = new Vector3(_parent.position.x, _parent.position.y, 0);
        _image.transform.eulerAngles = Vector3.zero;
        
        _occlusion.transform.position = _parent.position;
        _occlusion.transform.eulerAngles = Vector3.zero;
    }
}
