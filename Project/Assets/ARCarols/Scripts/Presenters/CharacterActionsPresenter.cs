using ARCarols.Scripts.Models;
using ARCarols.Scripts.UI.Panels;
using Project.Scripts.Presenters.Base;

namespace ARCarols.Scripts.Presenters
{
    public class CharacterActionsPresenter: PresenterBase<CharacterActionsModel, CharacterActionsView>
    {
        public CharacterActionsPresenter(CharacterActionsModel model, CharacterActionsView view) : base(model, view)
        {
            
        }
        protected override void ViewOpened()
        {
            base.ViewOpened();
            
            _model.CloseCharacterDialog();
        }
        
        protected override void ViewClosed()
        {
            base.ViewClosed();
        }
    }
}