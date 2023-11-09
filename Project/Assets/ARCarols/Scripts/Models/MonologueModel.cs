using Ar;
using ARCarols.Scripts.Character;
using ARCarols.Scripts.Character.Config;
using Project.Scripts.Models.Base;
using UniRx;
using UnityEngine;

namespace ARCarols.Scripts.Models
{
    public class MonologueModel : ModelBase
    {
        public IntReactiveProperty CurrentMonologueIndex;

        public ReactiveCommand OnEndMonologue = new();

        private CharacterConfig _currentCharacterConfig;

        private CurrentCharacterContainer _characterContainer;

        private ArManager _arManager;

        private CharacterAnimationController _characterAnimationController;

        private int _currentMonologueIndex = 0;


        public MonologueModel(CurrentCharacterContainer characterContainer, ArManager arManager)
        {
            _characterContainer = characterContainer;

            _arManager = arManager;
        }

        public void RefreshData()
        {
            _currentCharacterConfig = _characterContainer.CharacterConfig;

            _arManager.SetCharacterPrefab(_currentCharacterConfig)
                .ChangeArState(ArState.CharacterState)
                .GetCurrentCharacter();

            _currentMonologueIndex = 0;

            CurrentMonologueIndex = new IntReactiveProperty(_currentMonologueIndex);

            SetMonologueOnScene();
        }

        public void SetNextMonologue()
        {
            _currentMonologueIndex++;

            SetMonologueOnScene();
        }

        public void SetPreviousMonologue()
        {
            _currentMonologueIndex--;

            SetMonologueOnScene();
        }

        private void SetMonologueOnScene()
        {
            if (_currentCharacterConfig.CharacterTextConfig.TextList.Count == _currentMonologueIndex)
            {
                OnEndMonologue.Execute();
                return;
            }

            string textMonologue = _currentCharacterConfig.CharacterTextConfig.TextList[_currentMonologueIndex];

            Debug.Log("textMonologue: " + textMonologue);

            CurrentMonologueIndex.Value = _currentMonologueIndex;

            _characterAnimationController.SetText(textMonologue);
        }
    }
}