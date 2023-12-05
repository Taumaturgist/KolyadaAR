using System;
using System.Collections;
using ARCarols.Scripts.Character;
using ARCarols.Scripts.Character.Config;
using PanelManager.Scripts;
using UnityEngine;

namespace Ar
{
    public class ArManager : MonoBehaviour
    {
        public Action<CharacterAnimationController> OnCharacterSpawn
        {
            get => _characterPlaceOnSpace.OnCharacterSpawn;
            set => _characterPlaceOnSpace.OnCharacterSpawn += value;
        }

        [SerializeField] private ArFaceTrackingManager _arFaceTrackingManager;

        [SerializeField] private CharacterPlaceOnSpace _characterPlaceOnSpace;

        [SerializeField] private GameObject _componentsCharacter;

        [SerializeField] private GameObject _componentsFace;

        [SerializeField] private GameObject _popup;

        private ArState _currentState = ArState.CharacterState;

        private void Start()
        {
            ChangeArState(ArState.Off);
        }

        public void Init(PanelManagerBase panelManagerBase)
        {
            _characterPlaceOnSpace.Init(panelManagerBase);
        }

        public ArManager ChangeArState(ArState arState)
        {
            if (_currentState == arState && arState != ArState.Off)
            {
                return this;
            }
            
            switch (arState)
            {
                case ArState.Off:
                    _componentsCharacter.SetActive(false);
                    _componentsFace.SetActive(false);
                    break;
                case ArState.MaskState:
                    StartCoroutine(ShowPopupCoroutine());
                    _componentsCharacter.SetActive(false);
                    _componentsFace.SetActive(true);
                    break;
                case ArState.SelfieState:
                    StartCoroutine(ShowPopupCoroutine());
                    _componentsCharacter.SetActive(false);
                    _componentsFace.SetActive(true);
                    break;
                case ArState.CharacterState:
                    StartCoroutine(ShowPopupCoroutine());
                    _componentsFace.SetActive(false);
                    _componentsCharacter.SetActive(true);
                    break;
            }

            _currentState = arState;
            return this;
        }

        public void SetMask(MaskData mask = null)
        {
            _arFaceTrackingManager.ChangeMask(mask == null ? null : mask.Prefab);
        }

        public void SetSelfie(MaskData mask = null)
        {
            _arFaceTrackingManager.ChangeSelfie(mask == null ? null : mask.Prefab);
        }
        
        public ArManager SetCharacterPrefab(CharacterConfig character)
        {
            _characterPlaceOnSpace.AnchorPrefab = character.CharacterPrefabAr;
            return this;
        }

        public CharacterAnimationController GetCurrentCharacter()
        {
            return _characterPlaceOnSpace.CurrentCharacterOnScene;
        }

        private IEnumerator ShowPopupCoroutine()
        {
            _popup.SetActive(true);
            yield return new WaitForSeconds(2f);
            _popup.SetActive(false);
        }
    }
}