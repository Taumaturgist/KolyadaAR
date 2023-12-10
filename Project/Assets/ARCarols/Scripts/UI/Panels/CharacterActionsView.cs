using System;
using PanelManager.Scripts.Interfaces;
using PanelManager.Scripts.Panels;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Panels
{
    public class CharacterActionsView : ViewBase
    {
        [SerializeField] private TMP_Text _characterActionText;

        [SerializeField] private Button _buttonClose;

        [SerializeField] private Button _moveToSelphie;

        [SerializeField] private Button _moveToCharacterAction;

        [SerializeField] private Button _moveToMonologue;

        public IObservable<Unit> MoveToCharacterActionOnClick;

        public override PanelType PanelType => PanelType.Screen;
        public override bool RememberInHistory => false;

        protected override void OnInitialize()
        {
            base.OnInitialize();

            MoveToCharacterActionOnClick = _moveToCharacterAction.OnClickAsObservable();

            _buttonClose.onClick.AddListener(() => _panelManager.OpenPanel<MenuView>());

            _moveToMonologue.onClick.AddListener(() => _panelManager.OpenPanel<CharacterMonologueView>());

            _moveToSelphie.onClick.AddListener(() => _panelManager.OpenPanel<SelfieView>());
        }

        public void ActivateCharacterActions(bool isCharacterOnScene)
        {
            _moveToCharacterAction.interactable = isCharacterOnScene;
            
            _moveToMonologue.interactable = isCharacterOnScene;
        }

        public void SetCharacterActionText(string text)
        {
            _characterActionText.text = text;
        }

        public void OpenNextView(IView nextView)
        {
            _panelManager.OpenPanel(nextView);
        }
    }
}