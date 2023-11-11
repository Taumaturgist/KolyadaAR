using System;
using System.Collections.Generic;
using ARCarols.Scripts.UI.Component;
using DanielLochner.Assets.SimpleScrollSnap;
using PanelManager.Scripts.Panels;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Panels
{
    public class MaskView : ViewBase
    {
        [SerializeField] private Button _closeButton;

        [SerializeField] private TMP_Text _nameMask;

        [SerializeField] private MaskViewItem _maskViewItemPrefab;

        [SerializeField] private SimpleScrollSnap _simpleScrollSnap;

        [SerializeField] private Transform _spawnViewSpawnPoint;

        [SerializeField] private int _startIndex = 1;
        
        public int CurrentPanel => _simpleScrollSnap.CenteredPanel;

        public IObservable<int> ChangePanel;
        
        public override PanelType PanelType => PanelType.Screen;
        
        public override bool RememberInHistory => false;

        private List<MaskViewItem> _viewMaskItems = new();

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _closeButton.onClick.AddListener(() => _panelManager.OpenPanel<MenuView>());

            _simpleScrollSnap.OnPanelCentered.AddListener(ChangeInteractableState);
            
            ChangePanel = _simpleScrollSnap.OnPanelSelected.AsObservable();
        }

        public MaskViewItem CreateMaskViewItem()
        {
            var maskView = Instantiate(_maskViewItemPrefab, _spawnViewSpawnPoint);

            _viewMaskItems.Add(maskView);
            
            _simpleScrollSnap.AddToBack(maskView.gameObject);
            
            return maskView;
        }

        public void SetMaskName(string nameMask)
        {
            _nameMask.text = nameMask;
        }
        

        public void ClearMaskViewItems()
        {
            for (int i = 0; i < _viewMaskItems.Count; i++)
            {
                _simpleScrollSnap.RemoveFromFront();
            }

            _viewMaskItems.Clear();
        }

        public void GoToFirstPanel()
        {
            _simpleScrollSnap.GoToNextPanel();
            
            _simpleScrollSnap.GoToPanel(_startIndex);
            
            _viewMaskItems[_startIndex].SetInteractable(true);
        }

        private void ChangeInteractableState(int currentIndex, int previousIndex)
        {
            _viewMaskItems[previousIndex].SetInteractable(false);
            
            _viewMaskItems[currentIndex].SetInteractable(true);
        }

    }
}
