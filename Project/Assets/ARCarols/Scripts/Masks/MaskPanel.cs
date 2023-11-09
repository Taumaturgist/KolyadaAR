using System.Collections.Generic;
using ARCarols.Scripts.UI.Panels;
using UnityEngine;

public class MaskPanel : MonoBehaviour
{
    [SerializeField] private MaskView _maskViewPrefab;
    
    [SerializeField] private Transform _content;

    [SerializeField] private ArFaceTrackingManager _arFaceTrackingManager;

    private List<MaskView> _masksOnScene = new();

    private MaskData[] _masksData;
    private void Awake()
    {
        _masksData = Resources.LoadAll<MaskData>("Masks");

        SpawnContent(_masksData);
    }

    private void OnDestroy()
    {
        foreach (var mask in _masksOnScene)
        {
            Destroy(mask.gameObject);
        }
        _masksOnScene.Clear();
    }

    public void SpawnContent(MaskData[] masksData)
    {
        foreach (var data in masksData)
        {
           var maskView = Instantiate(_maskViewPrefab, _content);
           maskView.Init(data);
           maskView.OnClickButton += OnChangeMask;
           _masksOnScene.Add(maskView);
        }
    }

    private void OnChangeMask(MaskData maskData)
    {
        _arFaceTrackingManager.ChangeMask(maskData);
    }
    
}
