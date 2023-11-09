using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MaskView : MonoBehaviour
{
    public Action<MaskData> OnClickButton;
    
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Button _actionButton;

    private CompositeDisposable _disposable = new();

    private MaskData _maskData;

    public void Init(MaskData maskData)
    {
        _maskData = maskData;
        _name.text = _maskData.MaskName;

        _actionButton.OnClickAsObservable().Subscribe(_ => OnClickButton?.Invoke(_maskData));
    }

    private void OnDestroy()
    {
        _disposable.Dispose();
    }
}
