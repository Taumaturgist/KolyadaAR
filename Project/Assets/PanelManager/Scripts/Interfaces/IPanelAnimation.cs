using System;

namespace BurningKnight.PanelManager
{
    public interface IPanelAnimation
    {
        bool IsPlayingAnimation { get; }
        
        void AnimationOpen(Action callback);

        void AnimationClose(Action callback);
    }
}