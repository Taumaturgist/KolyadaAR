﻿using ARCarols.Scripts.Models;
using ARCarols.Scripts.UI.Panels;
using Project.Scripts.Presenters.Base;
using UniRx;

namespace ARCarols.Scripts.Presenters
{
    public class MonologuePresenter : PresenterBase<MonologueModel,CharacterMonologueView>
    {
        public MonologuePresenter(MonologueModel model, CharacterMonologueView view) : base(model, view)
        {
            
        }
        
        protected override void ViewOpened()
        {
            base.ViewOpened();
            
            _model.RefreshData();

            _view.ValidateButtonState(_model.CurrentMonologueIndex.Value);

            _model.OnEndMonologue.Subscribe(_ => _view.OpenCharacterView()).AddTo(_sessionDisposable);

            _model.CurrentMonologueIndex.Subscribe(_view.ValidateButtonState).AddTo(_sessionDisposable);

            _view.PreviousButtonOnClick.Subscribe(_ => _model.SetPreviousMonologue()).AddTo(_sessionDisposable);
            
            _view.NextButtonOnClick.Subscribe(_ => _model.SetNextMonologue()).AddTo(_sessionDisposable);
        }
        
        protected override void ViewClosed()
        {
            base.ViewClosed();
        }
    }
}