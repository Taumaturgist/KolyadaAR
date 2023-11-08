using System;
using PanelManager.Scripts.Panels;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Panels
{
    public class MaskView : ViewBase
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Button _actionButton;
    
        public Action<MaskData> OnClickButton;

        public override PanelType PanelType => PanelType.Screen;
        
        public override bool RememberInHistory => false;

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
}
