using Ar;
using ARCarols.Scripts.Character;
using PanelManager.Scripts.Interfaces;
using Project.Scripts.Models.Base;
using UniRx;

namespace ARCarols.Scripts.Models
{
    public class CharacterActionsModel : ModelBase
    {
        public string CharacterActionText => _characterContainer.CharacterConfig.CharacterActionText;

        public ReactiveCommand<bool> OnCharacterOnScene = new();
        
        private ArManager _arManager;

        private CurrentCharacterContainer _characterContainer;

        public CharacterActionsModel(ArManager arManager, CurrentCharacterContainer characterContainer)
        {
            _arManager = arManager;

            _characterContainer = characterContainer;
        }

        
        public void RefreshCharacterData()
        {
            _arManager.SetCharacterPrefab(_characterContainer.CharacterConfig)
                .ChangeArState(ArState.CharacterState);
            
            _arManager.OnCharacterSpawn += SetCharacterOnScene;
        }

        public void DisposeOnCharacterSpawn()
        {
            _arManager.OnCharacterSpawn -= SetCharacterOnScene;
        }
        

        public void CloseCharacterDialog()
        {
            _arManager.ChangeArState(ArState.CharacterState);

            var character = _arManager.GetCurrentCharacter();

            if (character != null)
            {
                character.SetText(null, null);
            }
            
            OnCharacterOnScene.Execute(CheckCharacterOnScene());
        }

        public IView GetPanelForCharacterEvent()
        {
            return _characterContainer.CharacterConfig.PanelForCharacterEvent;
        }
        
        public bool CheckCharacterOnScene()
        {
            if (_arManager.GetCurrentCharacter() != null)
            {
                return true;
            }

            return false;
        }
        
        
        private void SetCharacterOnScene(CharacterAnimationController character)
        {
            character.SetText(null, null);

            OnCharacterOnScene.Execute(CheckCharacterOnScene());
        }

    }
}