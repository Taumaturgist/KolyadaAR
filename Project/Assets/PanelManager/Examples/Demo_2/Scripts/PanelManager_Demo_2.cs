namespace BurningKnight.PanelManager.Demo_2
{
    public class PanelManager_Demo_2 : PanelManagerBase
    {
        private void Awake()
        {
            CreatePanelsFromSettings();

            OpenPanel<ViewADemo2>();
        }
    }
}