using System;
using System.Collections;
using System.Collections.Generic;
using ARCarols.Scripts.Character;
using ARCarols.Scripts.UI.Enum;
using ARCarols.Scripts.UI.Overlay;
using PanelManager.Scripts;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Ar
{
    public class CharacterPlaceOnSpace : MonoBehaviour
    {
        public Action<CharacterAnimationController> OnCharacterSpawn;

        public CharacterAnimationController AnchorPrefab
        {
            get => _anchorPrefab;
            set => _anchorPrefab = value;
        }

        public CharacterAnimationController CurrentCharacterOnScene => _currentCharacter;

        [SerializeField] private ARRaycastManager _raycastManager;


        private CharacterAnimationController _anchorPrefab;
        
        private static List<ARRaycastHit> s_Hits = new();

        private const float SPAWN_OFFSET = 10f;

        private CharacterAnimationController _currentCharacter;

        private PanelManagerBase _panelManager;

        public void Init(PanelManagerBase panelManagerBase)
        {
            _panelManager = panelManagerBase;
        }
        

        private void OnEnable()
        {
            StartCoroutine(SpawnCharacterCoroutine());
        }

        private void OnDisable()
        {
            if (_currentCharacter == null) return;
            
            Destroy(_currentCharacter.gameObject);
            
            _currentCharacter = null;
        }
        

        private IEnumerator SpawnCharacterCoroutine()
        {
            _panelManager?.OpenPanel<ArNotificationView, PopupEnum>(PopupEnum.ArWarning);
            while (!_raycastManager.Raycast(new Vector2(0.5f, 0.5f), s_Hits, TrackableType.PlaneWithinPolygon))
            {
                yield return null;
            }
            
            _panelManager?.ClosePanel<ArNotificationView>();

            var hitPose = s_Hits[0].pose;

            _currentCharacter = Instantiate(_anchorPrefab,
                new Vector3(hitPose.position.x, hitPose.position.y, hitPose.position.z + SPAWN_OFFSET),
                Quaternion.identity);
            
            OnCharacterSpawn?.Invoke(_currentCharacter);
        }
        
        
    }
}