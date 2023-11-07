using BurningKnight.PanelManager;
using Project.Scripts.Models.Interfaces;

namespace Project.Scripts.Presenters.Interfaces
{
    public interface IPresenter<TModel, TView>
        where TModel : IModel
        where TView : IView
    {
        void Dispose();
    }
}