using System.Collections.Generic;
using Ar;
using ARCarols.Scripts.Masks;
using Project.Scripts.Models.Base;
using Screenshoter;

namespace ARCarols.Scripts.Models
{
    public class MaskModel : ModelBase
    {
        public List<MaskData> MasksData => _maskListConfig.MasksData;

        private MaskListConfig _maskListConfig;

        private ArManager _arManager;

        private ScreenshotManager _screenshotManager;

        public MaskModel(ArManager arManager, ScreenshotManager screenshotManager, MaskListConfig maskListConfig)
        {
            _arManager = arManager;

            _screenshotManager = screenshotManager;

            _maskListConfig = maskListConfig;
        }

        public void SetArState()
        {
            _arManager.ChangeArState(ArState.MaskState);
        }

        public void SaveScreenshot()
        {
            _screenshotManager.TakeScreen();
        }

        public void SetMask(int index)
        {
            _arManager.SetMask(MasksData[index]);
        }

        public string GetMaskName(int index)
        {
            return MasksData[index].MaskName;
        }
    }
}