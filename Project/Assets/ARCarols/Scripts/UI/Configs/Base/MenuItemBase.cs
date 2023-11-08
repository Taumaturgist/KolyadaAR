using PanelManager.Scripts.Interfaces;
using PanelManager.Scripts.Panels;
using UnityEngine;

namespace ARCarols.Scripts.UI.Configs.Base
{
    [CreateAssetMenu(menuName = "Project/MenuItem/MenuItemBase", fileName = "Menu Item Base", order = 0)]
    public class MenuItemBase : ScriptableObject
    {
        [SerializeField] private string _name;
        
        [SerializeField] private string _description;
        
        [SerializeField] private GameObject _iconPrefab;

        [SerializeField] private ViewBase nextPanelForNavigate;

        public virtual string Name => _name;

        public virtual string Description => _description;

        public virtual GameObject IconPrefab => _iconPrefab;

        public IView NextPanel => nextPanelForNavigate;
    }
}
