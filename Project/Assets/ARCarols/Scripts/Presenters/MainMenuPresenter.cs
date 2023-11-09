using ARCarols.Scripts.Models;
using ARCarols.Scripts.UI.Panels;
using Project.Scripts.Presenters.Base;
using UniRx;

namespace ARCarols.Scripts.Presenters
{
    public class MainMenuPresenter : PresenterBase<MainMenuModel, MenuView>
    {
        public MainMenuPresenter(MainMenuModel model, MenuView view) : base(model, view)
        {
            
        }
        
        protected override void ViewOpened()
        {
            base.ViewOpened();

            _model.ChangeArState();

            for (int i = 0; i < _model.MenuItems.Count; i++)
            {
                var data = _model.MenuItems[i];
                
                var menuItem = _view.CreateMenuItem();
                
                menuItem.SetData(data.IconPrefab, data.Name, data.Description);
            }

            _view.DotsView.Init(_model.MenuItems.Count);
            
            _view.ChangePanel.Subscribe(_ => SetCurrent(_view.CurrentPanel)).AddTo(_sessionDisposable);
            
            _view.ChangePanel.Subscribe(_ => _view.DotsView.SetSelectDot(_view.CurrentPanel)).AddTo(_sessionDisposable);

            _view.SelectItemOnClick.Subscribe(_ => OpenNextView()).AddTo(_sessionDisposable);

            SetCurrent(0);

        }
        
        protected override void ViewClosed()
        {
            base.ViewClosed();
            
            _view.DotsView.ClearDots();

            _view.ClearMenuItem();
        }

        private void SetCurrent(int panelIndex)
        {
            _model.SetCurrentMenuItem(panelIndex);
        }

        private void OpenNextView()
        {
            var iView = _model.GetNextPanel();

            _view.OpenNextView(iView);
        }
    }
}