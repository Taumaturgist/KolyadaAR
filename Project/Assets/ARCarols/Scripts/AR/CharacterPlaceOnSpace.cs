using System;
using System.Collections;
using System.Collections.Generic;
using ARCarols.Scripts.Character;
using ARCarols.Scripts.UI.Enum;
using PanelManager.Scripts;
using Unity.Mathematics;
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


        [SerializeField] private GameObject _planePrefab;

        [SerializeField] private Camera _arCamera;
        
        private ARPlaneManager _arPlaneManager;

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
            if (_panelManager.SudoGetPanel<ArNotificationView>() != null)
            {
                _panelManager?.ClosePanel<ArNotificationView>();
            }

            StopAllCoroutines();

            if (_currentCharacter == null) return;

            Destroy(_currentCharacter.gameObject);

            _currentCharacter = null;
        }

        private void FixedUpdate()
        {
            if (_currentCharacter == null)
            {
                return;
            }

            _currentCharacter.transform.LookAt(_arCamera.transform);
        }


        private IEnumerator SpawnCharacterCoroutine()
        {
            if (_arPlaneManager != null)
            {
                ClearArPlaneManager();
            }
            
            _arPlaneManager = gameObject.AddComponent<ARPlaneManager>();
            
            _arPlaneManager.planePrefab = _planePrefab;

            _arPlaneManager.requestedDetectionMode = PlaneDetectionMode.Horizontal;
            
            _panelManager?.OpenPanel<ArNotificationView, PopupEnum>(PopupEnum.ArWarning);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            while (_currentCharacter == null)
            {
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                {
                    _raycastManager.Raycast(Input.touches[0].position, hits, TrackableType.Planes);
                    if (hits.Count > 0)
                    {
                        _currentCharacter = Instantiate(_anchorPrefab,
                            new Vector3(hits[0].pose.position.x, hits[0].pose.position.y + 0.5f,
                                hits[0].pose.position.z), quaternion.identity);
                        _currentCharacter.transform.LookAt(_arCamera.transform);
                    }
                }

                yield return null;
            }

            ClearArPlaneManager();

            _panelManager?.ClosePanel<ArNotificationView>();

            OnCharacterSpawn?.Invoke(_currentCharacter);
        }

        private void ClearArPlaneManager()
        {
            _arPlaneManager.planePrefab = null;

            foreach (var trackable in _arPlaneManager.trackables)
            {
                DestroyImmediate(trackable.gameObject);
            }
            
            DestroyImmediate(_arPlaneManager);
        }
    }
}