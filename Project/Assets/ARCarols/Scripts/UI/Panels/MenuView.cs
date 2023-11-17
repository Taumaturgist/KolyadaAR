using System;
using System.Collections.Generic;
using ARCarols.Scripts.UI.Component;
using DanielLochner.Assets.SimpleScrollSnap;
using PanelManager.Scripts.Interfaces;
using PanelManager.Scripts.Panels;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Panels
{
    public class MenuView : ViewBase
    {
        [SerializeField] private Transform _menuItemSpawnPoint;

        [SerializeField] private MenuItemView _menuItemView;

        [SerializeField] private SimpleScrollSnap _simpleScrollSnap;

        [SerializeField] private DotsView _dotsView;

        [SerializeField] private Button _selectButton;

        [SerializeField] private Button _buttonCloseApplication;

        public DotsView DotsView => _dotsView;

        public int CurrentPanel => _simpleScrollSnap.CenteredPanel;

        public IObservable<int> ChangePanel;
        
        public IObservable<Unit> SelectItemOnClick;
        
        public IObservable<Unit> ButtonCloseApplicationOnClick;

        private List<MenuItemView> _menuItemsView = new();

        public override PanelType PanelType => PanelType.Screen;
        public override bool RememberInHistory => false;

        protected override void OnInitialize()
        {
            SelectItemOnClick = _selectButton.onClick.AsObservable();
            ChangePanel = _simpleScrollSnap.OnPanelSelected.AsObservable();
            ButtonCloseApplicationOnClick = _buttonCloseApplication.OnClickAsObservable();
        }

        public void OpenNextView(IView nextView)
        {
            _panelManager.OpenPanel(nextView);
        }
        

        public MenuItemView CreateMenuItem()
        {
            var createdMenuItem = Instantiate(_menuItemView, _menuItemSpawnPoint);
            
            _menuItemsView.Add(createdMenuItem);
            
            _simpleScrollSnap.AddToBack(createdMenuItem.gameObject);

            return createdMenuItem;
        }

        public void ClearMenuItem()
        {
            for (int i = 0; i < _menuItemsView.Count; i++)
            {
                _simpleScrollSnap.RemoveFromFront();
            }

            _menuItemsView.Clear();
        }
    }
}
