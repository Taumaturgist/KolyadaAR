using Ar;
using ARCarols.Scripts.Character;
using ARCarols.Scripts.Character.Config;
using PanelManager.Scripts;
using Project.Scripts.Models.Base;
using UniRx;
using UnityEngine;

namespace ARCarols.Scripts.Models
{
    public class MonologueModel : ModelBase
    {
        public IntReactiveProperty CurrentMonologueIndex;

        public ReactiveCommand OnEndMonologue = new();
        
        public ReactiveCommand<bool> OnPlayerSpawned = new();

        private CharacterConfig _currentCharacterConfig;

        private CurrentCharacterContainer _characterContainer;

        private ArManager _arManager;

        private CharacterAnimationController _characterAnimationController;

        private int _currentMonologueIndex = 0;


        public MonologueModel(CurrentCharacterContainer characterContainer, ArManager arManager,
            PanelManagerBase panelManagerBase)
        {
            _characterContainer = characterContainer;

            _arManager = arManager;

            _arManager.Init(panelManagerBase);
        }
        
        public void SubscribeOnCharacterSpawn()
        {
            _arManager.OnCharacterSpawn += SetCharacterOnScene;
        }
        
        public void DisposeOnCharacterSpawn()
        {
            _arManager.OnCharacterSpawn -= SetCharacterOnScene;
        }

        public void RefreshData()
        {
            _currentMonologueIndex = 0;

            _currentCharacterConfig = _characterContainer.CharacterConfig;
            
            Debug.Log($"OPEN MONOLOGUE {_currentCharacterConfig.Name}");

            _arManager.SetCharacterPrefab(_currentCharacterConfig)
                .ChangeArState(ArState.CharacterState);

            CurrentMonologueIndex = new IntReactiveProperty(_currentMonologueIndex);

            var characterAnimationController = _arManager.GetCurrentCharacter();

            if (characterAnimationController != null)
            {
                SetCharacterOnScene(characterAnimationController);
            }
        }


        public bool CheckCharacterExist()
        {
            if (_characterAnimationController != null)
            {
                return true;
            }

            return false;
        }
        
        public void EditMonologueIndex(int value)
        {
            if (_characterAnimationController == null)
            {
                Debug.LogError("No Character On AR Scene");
                return;
            }
            if (_characterAnimationController.IsTextWriting)
            {
                _characterAnimationController.SkipAnimation();
                return;
            }

            _currentMonologueIndex += value;

            SetMonologueOnScene();
        }


        private void SetCharacterOnScene(CharacterAnimationController characterAnimationController)
        {
            _characterAnimationController = characterAnimationController;
            
            OnPlayerSpawned?.Execute(true);
            
            SetMonologueOnScene();
        }

        private void SetMonologueOnScene()
        {
            if (_characterAnimationController == null)
            {
                Debug.LogError("No Character On AR Scene");
                return;
            }

            if (_currentCharacterConfig.CharacterTextConfig.CharacterTextProviders.Count == _currentMonologueIndex)
            {
                OnEndMonologue.Execute();

                _characterContainer.EndMonologueCurrentCharacter();

                return;
            }

            var monologue = _currentCharacterConfig.CharacterTextConfig.CharacterTextProviders[_currentMonologueIndex];

            if (CurrentMonologueIndex.Value != _currentMonologueIndex)
            {
                CurrentMonologueIndex.Value = _currentMonologueIndex;
            }

            _characterAnimationController.SetText(monologue.Text, monologue.AudioClip);
        }
    }
}