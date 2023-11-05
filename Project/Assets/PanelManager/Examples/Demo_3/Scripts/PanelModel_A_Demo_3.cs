namespace BurningKnight.PanelManager.Demo_3
{
    public class PanelModel_A_Demo_3 : PanelModelBase
    {
        protected override void OnInitialize() {}

        public override void OnPanelOpened() {}

        public override void OnPanelClosed() {}

        public void OpenSettings()
        {
            _panelManager.OpenPanel<ViewBDemo3>();
        }
    }
}