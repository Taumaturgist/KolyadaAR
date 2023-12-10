using ARCarols.Scripts.Models;
using ARCarols.Scripts.UI.Panels;
using Project.Scripts.Presenters.Base;
using UniRx;

namespace ARCarols.Scripts.Presenters
{
    public class KolyadaActionPresenter : PresenterBase<KolyadaActionModel, GrandfatherKolyadaActionView>
    {
        public KolyadaActionPresenter(KolyadaActionModel model, GrandfatherKolyadaActionView view) : base(model, view)
        {
        }

        protected override void ViewOpened()
        {
            base.ViewOpened();

            _view.StartActionOnClick.Subscribe(_ => _model.SetCharacterText()).AddTo(_sessionDisposable);
        }

        protected override void ViewClosed()
        {
            base.ViewClosed();
        }
    }
}