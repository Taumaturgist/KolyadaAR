using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Ar
{
    public class CharacterPlaceOnSpace : MonoBehaviour
    {
        public CharacterArView AnchorPrefab
        {
            get => _anchorPrefab;
            set => _anchorPrefab = value;
        }

        public CharacterArView CurrentCharacterOnScene => _currentCharacter;

        [SerializeField] private ARRaycastManager _raycastManager;
        
        private CharacterArView _anchorPrefab;
        
        private static List<ARRaycastHit> s_Hits = new();

        private const float SPAWN_OFFSET = 5f;

        private CharacterArView _currentCharacter;
        

        private void OnEnable()
        {
            StartCoroutine(SpawnCharacterCoroutine());
        }

        private void OnDisable()
        {
            Destroy(_currentCharacter.gameObject);
            _currentCharacter = null;
        }

        private IEnumerator SpawnCharacterCoroutine()
        {
            while (!_raycastManager.Raycast(new Vector2(0.5f, 0.5f), s_Hits, TrackableType.PlaneWithinPolygon))
            {
                yield return null;
            }

            var hitPose = s_Hits[0].pose;

            _currentCharacter = Instantiate(_anchorPrefab,
                new Vector3(hitPose.position.x, hitPose.position.y, hitPose.position.z + SPAWN_OFFSET),
                Quaternion.identity);
        }
    }
}