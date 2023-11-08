using System.Collections.Generic;
using ARCarols.Scripts.UI.Configs.Base;
using UnityEngine;

namespace ARCarols.Scripts.UI.Configs
{
    [CreateAssetMenu(menuName = "Project/MenuItem/MenuItemsConfig", fileName = "Menu Items Config", order = 0)]
    public class MenuItemsConfig : ScriptableObject
    {
        [SerializeField] private List<MenuItemBase> _menuItems = new();

        public List<MenuItemBase> MenuItems => _menuItems;
    }
}
