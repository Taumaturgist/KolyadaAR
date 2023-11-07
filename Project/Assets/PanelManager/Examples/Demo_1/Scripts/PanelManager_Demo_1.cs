namespace BurningKnight.PanelManager.Demo_1
{
    public class PanelManager_Demo_1 : PanelManagerBase
    {
        private void Awake()
        {
            CreatePanelsFromSettings();

            OpenPanel<ViewADemo1>();
        }
    }
}