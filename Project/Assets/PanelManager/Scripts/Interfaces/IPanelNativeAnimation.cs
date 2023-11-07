using System;
using UnityEngine;

namespace BurningKnight.PanelManager
{
    public interface IPanelNativeAnimation
    {
        event Action AnimationEnded;
        void StartAnimation(Transform animationTransform, AnimationCurve curve);
        void SetDefault();
        void StopAnimation();
    }
}