using BurningKnight.PanelManager;

namespace PanelManager.Examples.Demo_4.Scripts
{
    public class PanelManager_Demo_4 : PanelManagerBase
    {
        private void Awake()
        {
            CreatePanelsFromSettings();

            OpenPanel<ViewAnimationADemo4>();
        }
    }
}
