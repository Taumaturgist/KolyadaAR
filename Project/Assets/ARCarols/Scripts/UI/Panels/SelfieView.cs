using System;
using PanelManager.Scripts.Panels;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Panels
{
    public class SelfieView : ViewBase
    {
        [SerializeField] private Button _closeButton; 
        
        [SerializeField] private Button _createSelfieButton;

        public override PanelType PanelType => PanelType.Screen;
        public override bool RememberInHistory => false;

        public IObservable<Unit> CreateSelpfieOnClick => _createSelfieButton.onClick.AsObservable();

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _closeButton.onClick.AddListener(() => _panelManager.OpenPanel<MenuView>());
        }
    }
}
