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
        }

        public void CloseCharacterDialog()
        {
            var character = _arManager.GetCurrentCharacter();
            
            character.SetText(null);
        }
        
        public IView GetPanelForCharacterEvent()
        {
            return _characterContainer.CharacterConfig.PanelForCharacterEvent;
        }
    }
}
