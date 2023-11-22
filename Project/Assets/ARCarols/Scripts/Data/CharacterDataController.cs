using ARCarols.Scripts.Character.Config;
using ARCarols.Scripts.Data.Base;

namespace ARCarols.Scripts.Data
{
    public class CharacterDataController: DataControllerBase<CharacterData>
    {
        public bool IsCompletedMonologue
        {
            get => Data.IsCompletedMonologue;
            set
            {
                Data.IsCompletedMonologue = value;
                
                Save();
            }
        }
        
        private CharacterConfig _characterConfig;
        
        public CharacterDataController(CharacterConfig characterConfig)
        {
            _characterConfig = characterConfig;
        }

        protected override string DataKey => "Character_" + _characterConfig.name;
        protected override CharacterData CreatDefault()
        {
            var characterData = new CharacterData()
            {
                IsCompletedMonologue = false
            };
            return characterData;
        }
    }
}