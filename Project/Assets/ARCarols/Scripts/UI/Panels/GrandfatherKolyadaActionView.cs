using System;
using PanelManager.Scripts.Panels;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Panels
{
    public class GrandfatherKolyadaActionView : ViewBase
    {

        [SerializeField] private Button _closeButton;

        [SerializeField] private Button _startAction;

        public IObservable<Unit> StartActionOnClick => _startAction.onClick.AsObservable();
        
        public override PanelType PanelType => PanelType.Screen;

        public override bool RememberInHistory => false;
        

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _closeButton.onClick.AddListener(() => _panelManager.OpenPanel<CharacterActionsView>());
        }
        
        
        


    }
}