using ARCarols.Scripts.Models;
using ARCarols.Scripts.UI.Panels;
using Project.Scripts.Presenters.Base;
using UniRx;

namespace ARCarols.Scripts.Presenters
{
    public class CharacterActionsPresenter : PresenterBase<CharacterActionsModel, CharacterActionsView>
    {
        public CharacterActionsPresenter(CharacterActionsModel model, CharacterActionsView view) : base(model, view)
        {
        }

        protected override void ViewOpened()
        {
            base.ViewOpened();

            _model.SubscribeOnCharacterSpawn();
            _model.CloseCharacterDialog();

            _view.MoveToCharacterActionOnClick.Subscribe(_ => _view.OpenNextView(_model.GetPanelForCharacterEvent()));
        }


        protected override void ViewClosed()
        {
            base.ViewClosed();

            _model.DisposeOnCharacterSpawn();
        }
    }
}