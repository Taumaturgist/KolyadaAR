using Ar;
using Project.Scripts.Models.Base;
using Screenshoter;

namespace ARCarols.Scripts.Models
{
    public class SelfieModel: ModelBase
    {
        private ArManager _arManager;
        
        private ScreenshotManager _screenshotManager;
        
        public SelfieModel(ArManager arManager, ScreenshotManager screenshotManager)
        {
            _arManager = arManager;

            _screenshotManager = screenshotManager;
        }

        public void SetARState()
        {
            _arManager.ChangeArState(ArState.SelfieState);
        }
        
        public void SaveScreenshot()
        {
            _screenshotManager.TakeScreen();
        }
    }
}