using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Ar
{
    public class CharacterPlaceOnSpace : MonoBehaviour
    {
        public GameObject AnchorPrefab
        {
            get => _anchorPrefab;
            set => _anchorPrefab = value;
        }

        [SerializeField] GameObject _anchorPrefab;
        
        [SerializeField] private ARRaycastManager _raycastManager;

        private List<GameObject> _characters = new();

        private static List<ARRaycastHit> s_Hits = new();

        private const float SPAWN_OFFSET = 5f;
        

        private void OnEnable()
        {
            StartCoroutine(SpawnCharacterCoroutine());
        }

        private void OnDisable()
        {
            if (_characters == null || _characters.Count == 0)
            {
                return;
            }
            foreach (var character in _characters)
            {
                Destroy(character.gameObject);
            }
            _characters.Clear();
        }

        private IEnumerator SpawnCharacterCoroutine()
        {
            while (!_raycastManager.Raycast(new Vector2(0.5f, 0.5f), s_Hits, TrackableType.PlaneWithinPolygon))
            {
                yield return null;
            }

            var hitPose = s_Hits[0].pose;

           var character = Instantiate(_anchorPrefab,
                new Vector3(hitPose.position.x, hitPose.position.y, hitPose.position.z + SPAWN_OFFSET),
                Quaternion.identity);
           _characters.Add(character);
        }
    }
}