using PanelManager.Scripts.Panels;
using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Panels
{
    public class CharacterActionsView : ViewBase
    {
        [SerializeField] private Button _buttonClose;

        [SerializeField] private Button _moveToSelphie;

        [SerializeField] private Button _moveToCharacterAction;

        [SerializeField] private Button _moveToMonologue;
        
        public override PanelType PanelType => PanelType.Screen;
        public override bool RememberInHistory => false;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _buttonClose.onClick.AddListener(() => _panelManager.OpenPanel<MenuView>());
            
            _moveToMonologue.onClick.AddListener(() => _panelManager.OpenPanel<CharacterMonologueView>());
            
            _moveToSelphie.onClick.AddListener(() => _panelManager.OpenPanel<SelfieView>());
        }
    }
}
