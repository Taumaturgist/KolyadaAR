using UnityEngine;

namespace BurningKnight.PanelManager
{
    [CreateAssetMenu(menuName = "PanelManager/Panel Manager Settings", fileName = "PanelManagerSettings", order = -1000)]
    public class PanelManagerSettings : ScriptableObject
    {
        public ViewBase[] Panels;
    }
}