using System.Collections.Generic;
using ARCarols.Scripts.UI.Configs;
using ARCarols.Scripts.UI.Configs.Base;
using PanelManager.Scripts.Interfaces;
using Project.Scripts.Models.Base;

namespace ARCarols.Scripts.Models
{
    public class MainMenuModel : ModelBase
    {
        public List<MenuItemBase> MenuItems => _menuItemsConfig.MenuItems;

        private MenuItemsConfig _menuItemsConfig;

        private MenuItemBase _currentItem;

        public MainMenuModel(MenuItemsConfig menuItemsConfig)
        {
            _menuItemsConfig = menuItemsConfig;
        }

        public void SetCurrentMenuItem(int index)
        {
            _currentItem = MenuItems[index];
        }

        public IView GetNextPanel()
        {
            if (_currentItem is CharacterMenuItem)
            {
                //Засетить префаб для отображения в AR
            }

            return _currentItem.NextPanel;
        }
    }
}