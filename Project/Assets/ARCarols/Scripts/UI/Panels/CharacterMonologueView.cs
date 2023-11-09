using System;
using PanelManager.Scripts.Panels;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Panels
{
    public class CharacterMonologueView : ViewBase
    {
        [SerializeField] private Button _buttonCloseView;

        [SerializeField] private Button _buttonPreviousView;

        [SerializeField] private Button _buttonNextView;

        public IObservable<Unit> PreviousButtonOnClick => _buttonPreviousView.onClick.AsObservable();
        public IObservable<Unit> NextButtonOnClick => _buttonNextView.onClick.AsObservable();

        public override PanelType PanelType => PanelType.Screen;
        public override bool RememberInHistory => false;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _buttonCloseView.onClick.AddListener(() => _panelManager.OpenPanel<MenuView>());
        }

        public void ValidateButtonState(int currentIndex)
        {
            _buttonPreviousView.gameObject.SetActive(currentIndex != 0);
        }

        public void OpenCharacterView()
        {
            _panelManager.OpenPanel<CharacterActionsView>();
        }
    }
}