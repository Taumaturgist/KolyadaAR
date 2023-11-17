using System.Collections.Generic;
using Ar;
using ARCarols.Scripts.Character;
using ARCarols.Scripts.UI.Configs;
using ARCarols.Scripts.UI.Configs.Base;
using PanelManager.Scripts.Interfaces;
using Project.Scripts.Models.Base;
using UnityEngine.Device;

namespace ARCarols.Scripts.Models
{
    public class MainMenuModel : ModelBase
    {
        public List<MenuItemBase> MenuItems => _menuItemsConfig.MenuItems;

        private MenuItemsConfig _menuItemsConfig;

        private CurrentCharacterContainer _characterContainer;

        private MenuItemBase _currentItem;
        
        private ArManager _arManager;

        public MainMenuModel(MenuItemsConfig menuItemsConfig, CurrentCharacterContainer characterContainer, ArManager arManager)
        {
            _characterContainer = characterContainer;
            
            _menuItemsConfig = menuItemsConfig;

            _arManager = arManager;
        }

        public void ChangeArState()
        {
            _arManager.ChangeArState(ArState.Off);
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

        public void CloseApplication()
        {
            Application.Quit();
        }
    }
}