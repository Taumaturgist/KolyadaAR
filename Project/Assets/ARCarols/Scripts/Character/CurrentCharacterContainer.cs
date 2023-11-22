using System.Collections.Generic;
using ARCarols.Scripts.Character.Config;
using ARCarols.Scripts.Data;

namespace ARCarols.Scripts.Character
{
    public class CurrentCharacterContainer
    {
        public CharacterConfig CharacterConfig => _currentCharacterConfig;

        private CharacterConfig _currentCharacterConfig;

        private CharacterDataController _currentCharacterDataController;
        
        private Dictionary<string, CharacterDataController> _dataControllers = new();

        public void SetCurrentCharacter(CharacterConfig characterConfig)
        {
            _currentCharacterConfig = characterConfig;

            CreatOrSetDataController(_currentCharacterConfig);
        }

        public bool CheckCompleteMonologue()
        {
            return _currentCharacterDataController.IsCompletedMonologue;
        }

        public void EndMonologueCurrentCharacter()
        {
            _currentCharacterDataController.IsCompletedMonologue = true;
        }
        
        private void CreatOrSetDataController(CharacterConfig config)
        {
            if (_dataControllers.TryGetValue(config.name, out var controller))
            {
                _currentCharacterDataController = controller;
            }
            else
            {
                _currentCharacterDataController = new CharacterDataController(config);

                _currentCharacterDataController.Load();

                _dataControllers.Add(config.name, _currentCharacterDataController);
            }
        }



    }
}