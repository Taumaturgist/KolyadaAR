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

            _model.OnCharacterOnScene.Subscribe(_ => _view.ActivateCharacterActions(_)).AddTo(_sessionDisposable);

            _model.RefreshCharacterData();
            
            _model.CloseCharacterDialog();

            _view.ActivateCharacterActions(_model.CheckCharacterOnScene());

            _view.SetCharacterActionText(_model.CharacterActionText);
            
            _view.MoveToCharacterActionOnClick.Subscribe(_ => _view.OpenNextView(_model.GetPanelForCharacterEvent())).AddTo(_sessionDisposable);
        }


        protected override void ViewClosed()
        {
            base.ViewClosed();

            _model.DisposeOnCharacterSpawn();
        }
    }
}