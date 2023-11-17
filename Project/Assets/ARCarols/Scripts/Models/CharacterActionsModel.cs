using Ar;
using ARCarols.Scripts.Character;
using ARCarols.Scripts.UI.Configs;
using PanelManager.Scripts.Interfaces;
using Project.Scripts.Models.Base;

namespace ARCarols.Scripts.Models
{
    public class CharacterActionsModel : ModelBase
    {
        private ArManager _arManager;
        
        private CurrentCharacterContainer _characterContainer; 
        
        public CharacterActionsModel(ArManager arManager, CurrentCharacterContainer characterContainer)
        {
            _arManager = arManager;

            _characterContainer = characterContainer;
            _arManager.OnCharacterSpawn += SetCharacterOnScene;
            
        }

        private void SetCharacterOnScene(CharacterAnimationController character)
        {
            character.SetText(null);
        }

        public void CloseCharacterDialog()
        {
            _arManager.ChangeArState(ArState.CharacterState);
            
            var character = _arManager.GetCurrentCharacter();

            if (character != null)
            {
                character.SetText(null);
            }

        }
        
        public IView GetPanelForCharacterEvent()
        {
            return _characterContainer.CharacterConfig.PanelForCharacterEvent;
        }
    }
}
