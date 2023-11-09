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
            
            _arManager.OnCharacterSpawn += SetCharacterOnScene;
        }

        public void RefreshData()
        {
            _currentCharacterConfig = _characterContainer.CharacterConfig;

            _arManager.SetCharacterPrefab(_currentCharacterConfig)
                .ChangeArState(ArState.CharacterState);

            _currentMonologueIndex = 0;

            CurrentMonologueIndex = new IntReactiveProperty(_currentMonologueIndex);
            
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


        private void SetCharacterOnScene(CharacterAnimationController characterAnimationController)
        {
            Debug.Log("SetCharacterOnScene");
            
            _characterAnimationController = characterAnimationController;
            
            SetMonologueOnScene();
        }

        private void SetMonologueOnScene()
        {
            if (_characterAnimationController == null)
            {
                Debug.LogError("No Character On AR Scene");
                return;
            }
            
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