using ARCarols.Scripts.Models;
using ARCarols.Scripts.UI.Panels;
using Project.Scripts.Presenters.Base;
using UniRx;

namespace ARCarols.Scripts.Presenters
{
    public class SelfiePresenters: PresenterBase<SelfieModel, SelfieView>
    {
        public SelfiePresenters(SelfieModel model, SelfieView view) : base(model, view)
        {
            
        }
        
        protected override void ViewOpened()
        {
            base.ViewOpened();
            
            _model.SetARState();

            _view.CreateSelpfieOnClick.Subscribe(_ => _model.SaveScreenshot()).AddTo(_sessionDisposable);
        }
        
        protected override void ViewClosed()
        {
            _model.ResetMask();
            base.ViewClosed();
        }
    }
}