using UnityEngine;

public class ArSelfieMask : MonoBehaviour
{
    [SerializeField] private TestArFaceFixer _testArFaceFixer;

    private void OnDestroy()
    {
        Destroy(_testArFaceFixer.gameObject);
    }
}
