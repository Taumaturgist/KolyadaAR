using DG.Tweening;
using PanelManager.Scripts.Panels;
using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Panels
{
    public class GrandfatherKolyadaActionView : ViewBase
    {

        [SerializeField] private Button _closeButton;

        [SerializeField] private Button _startAction;

        public override PanelType PanelType => PanelType.Screen;

        public override bool RememberInHistory => false;
        

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _closeButton.onClick.AddListener(() => _panelManager.OpenPanel<CharacterActionsView>());
            
        }
        


    }
}