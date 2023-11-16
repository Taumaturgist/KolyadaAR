using Ar;
using ARCarols.Scripts.Character;
using Project.Scripts.Models.Base;
using Screenshoter;

namespace ARCarols.Scripts.Models
{
    public class SelfieModel: ModelBase
    {
        private ArManager _arManager;
        
        private ScreenshotManager _screenshotManager;

        private CurrentCharacterContainer _characterContainer;
        
        public SelfieModel(ArManager arManager, ScreenshotManager screenshotManager, CurrentCharacterContainer characterContainer)
        {
            _arManager = arManager;

            _screenshotManager = screenshotManager;

            _characterContainer = characterContainer;
        }

        public void SetARState()
        {
            _arManager.ChangeArState(ArState.SelfieState);
            
            _arManager.SetMask(_characterContainer.CharacterConfig.SelfieData);
        }

        public void ResetMask()
        {
            _arManager.SetMask(null);
        }
        
        public void SaveScreenshot()
        {
            _screenshotManager.TakeScreen();
        }
    }
}