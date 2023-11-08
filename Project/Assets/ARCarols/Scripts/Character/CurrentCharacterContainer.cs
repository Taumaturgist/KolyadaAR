using ARCarols.Scripts.Character.Config;

namespace ARCarols.Scripts.Character
{
    public class CurrentCharacterContainer
    {
        public CharacterConfig CharacterConfig => _currentCharacterConfig;

        private CharacterConfig _currentCharacterConfig;

        public void SetCurrentCharacterConfig(CharacterConfig characterConfig)
        {
            _currentCharacterConfig = characterConfig;
        }
    }
}