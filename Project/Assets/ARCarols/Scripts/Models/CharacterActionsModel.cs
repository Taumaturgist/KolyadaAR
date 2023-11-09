using Ar;
using Project.Scripts.Models.Base;

namespace ARCarols.Scripts.Models
{
    public class CharacterActionsModel : ModelBase
    {
        private ArManager _arManager;
        
        public CharacterActionsModel(ArManager arManager)
        {
            _arManager = arManager;
        }

        public void CloseCharacterDialog()
        {
            var character = _arManager.GetCurrentCharacter();
            
            character.SetText(null);
        }
    }
}
