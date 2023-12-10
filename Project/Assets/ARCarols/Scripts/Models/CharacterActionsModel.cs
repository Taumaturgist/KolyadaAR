using Ar;
using ARCarols.Scripts.Character;
using PanelManager.Scripts.Interfaces;
using Project.Scripts.Models.Base;

namespace ARCarols.Scripts.Models
{
    public class CharacterActionsModel : ModelBase
    {
        public string CharacterActionText => _characterContainer.CharacterConfig.CharacterActionText;
        
        private ArManager _arManager;

        private CurrentCharacterContainer _characterContainer;

        public CharacterActionsModel(ArManager arManager, CurrentCharacterContainer characterContainer)
        {
            _arManager = arManager;

            _characterContainer = characterContainer;
        }

        public void SubscribeOnCharacterSpawn()
        {
            _arManager.OnCharacterSpawn += SetCharacterOnScene;
        }

        public void DisposeOnCharacterSpawn()
        {
            _arManager.OnCharacterSpawn -= SetCharacterOnScene;
        }

        private void SetCharacterOnScene(CharacterAnimationController character)
        {
            character.SetText(null, null);
        }

        public void CloseCharacterDialog()
        {
            _arManager.ChangeArState(ArState.CharacterState);

            var character = _arManager.GetCurrentCharacter();

            if (character != null)
            {
                character.SetText(null, null);
            }
        }

        public IView GetPanelForCharacterEvent()
        {
            return _characterContainer.CharacterConfig.PanelForCharacterEvent;
        }
    }
}