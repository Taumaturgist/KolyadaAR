using System.Collections.Generic;
using ARCarols.Scripts.Character;
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

        private CurrentCharacterContainer _characterContainer;

        private MenuItemBase _currentItem;

        public MainMenuModel(MenuItemsConfig menuItemsConfig, CurrentCharacterContainer characterContainer)
        {
            _characterContainer = characterContainer;
            
            _menuItemsConfig = menuItemsConfig;
        }

        public void SetCurrentMenuItem(int index)
        {
            _currentItem = MenuItems[index];
        }

        public IView GetNextPanel()
        {
            //Set Current Character
            if (_currentItem is CharacterMenuItem item)
            {
                _characterContainer.SetCurrentCharacterConfig(item.CharacterConfig);
            }

            return _currentItem.NextPanel;
        }
    }
}