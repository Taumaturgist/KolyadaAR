namespace BurningKnight.PanelManager
{
    public interface IAcceptArg<in T>
    {
        void AcceptArg(T arg);
    }
}