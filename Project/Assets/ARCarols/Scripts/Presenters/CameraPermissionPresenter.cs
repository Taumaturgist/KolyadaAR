using ARCarols.Scripts.Models;
using ARCarols.Scripts.UI.Overlay;
using Project.Scripts.Presenters.Base;
using UniRx;

namespace ARCarols.Scripts.Presenters
{
    public class CameraPermissionPresenter : PresenterBase<CameraPermissionModel, CameraPermissionView>
    {
        
        public CameraPermissionPresenter(CameraPermissionModel model, CameraPermissionView view) : base(model, view)
        {
            _model.OnCameraRequest.Subscribe(_ => _view.Open());
        }

        protected override void ViewOpened()
        {
            base.ViewOpened();
            
            _view.SkipButtonClick.Subscribe(_ => OnCloseView()).AddTo(_sessionDisposable);
            
        }

        protected override void ViewClosed()
        {
            base.ViewClosed();
        }

        private void OnCloseView()
        {
            _model.UpdateRequestCameraPermission();
            _view.Close();
        }
    }
}