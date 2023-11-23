using System.Collections.Generic;
using Ar;
using ARCarols.Scripts.Character;
using ARCarols.Scripts.Character.Config;
using ARCarols.Scripts.Data;
using ARCarols.Scripts.UI.Configs;
using ARCarols.Scripts.UI.Configs.Base;
using PanelManager.Scripts.Interfaces;
using Project.Scripts.Models.Base;
using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace ARCarols.Scripts.Models
{
    public class MainMenuModel : ModelBase
    {
        public List<MenuItemBase> MenuItems => _menuItemsConfig.MenuItems;

        private MenuItemsConfig _menuItemsConfig;

        private CurrentCharacterContainer _characterContainer;

        private MenuItemBase _currentItem;

        private ArManager _arManager;

        private IView _panelForCompleteMonologueCharacter;

        public MainMenuModel(MenuItemsConfig menuItemsConfig, CurrentCharacterContainer characterContainer,
            ArManager arManager, IView panelForCompleteMonologueCharacter)
        {
            _characterContainer = characterContainer;

            _menuItemsConfig = menuItemsConfig;

            _arManager = arManager;

            _panelForCompleteMonologueCharacter = panelForCompleteMonologueCharacter;
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
                _characterContainer.SetCurrentCharacter(item.CharacterConfig);
                
                Debug.Log(_characterContainer);

                if (_characterContainer.CheckCompleteMonologue())
                {
                    return _panelForCompleteMonologueCharacter;
                }
                
            }

            return _currentItem.NextPanel;
        }

        public void CloseApplication()
        {
            Application.Quit();
        }

       
    }
}