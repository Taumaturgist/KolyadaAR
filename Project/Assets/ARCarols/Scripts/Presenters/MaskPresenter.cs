using ARCarols.Scripts.Models;
using ARCarols.Scripts.UI.Panels;
using Project.Scripts.Presenters.Base;
using UniRx;

namespace ARCarols.Scripts.Presenters
{
    public class MaskPresenter : PresenterBase<MaskModel, MaskView>
    {
        public MaskPresenter(MaskModel model, MaskView view) : base(model, view)
        {
            
        }

        protected override void ViewOpened()
        {
            base.ViewOpened();

            _model.SetArState();

            for (var index = 0; index < _model.MasksData.Count; index++)
            {
                var item = _model.MasksData[index];

                var maskItem = _view.CreateMaskViewItem();

                maskItem.Init()
                        .SetIcon(item.Icon);

                maskItem.OnClickButton.Subscribe(_ => _model.SaveScreenshot()).AddTo(_sessionDisposable);
            }

            _view.ChangePanel.Subscribe(_ => SetCurrent(_view.CurrentPanel)).AddTo(_sessionDisposable);

            _view.ChangePanel.Subscribe(_ => SetMaskName(_view.CurrentPanel)).AddTo(_sessionDisposable);
            
            _view.GoToFirstPanel();
        }

        protected override void ViewClosed()
        {
            base.ViewClosed();

            _view.ClearMaskViewItems();
        }

        private void SetCurrent(int maskIndex)
        {
            _model.SetMask(maskIndex);
        }

        private void SetMaskName(int maskIndex)
        {
            _view.SetMaskName(_model.GetMaskName(maskIndex));
        }
    }
}