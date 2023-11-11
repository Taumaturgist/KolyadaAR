using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Component
{
    public class MaskViewItem : MonoBehaviour
    {
        [SerializeField] private Image _maskImage;
        
        [SerializeField] private Button _buttonAction;
        
        public IObservable<Unit> OnClickButton;

        public MaskViewItem Init()
        {
            OnClickButton = _buttonAction.OnClickAsObservable();
            
            return this;
        }
        public void SetIcon(Sprite maskSprite)
        {
            _maskImage.sprite = maskSprite;
        }

        public void SetInteractable(bool isInteractable)
        {
            _buttonAction.interactable = isInteractable;
        }
    }
}
