using UnityEngine;

[CreateAssetMenu(fileName = "MaskData", menuName = "Project/Character/MaskData")]
public class MaskData : ScriptableObject
{
    public GameObject Prefab => _prefab;
    public int ID => _id;
    public string MaskName => _maskName;
    public Sprite Icon => _icon;

    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _id;
    [SerializeField] private string _maskName;
    [SerializeField] private Sprite _icon;
}
