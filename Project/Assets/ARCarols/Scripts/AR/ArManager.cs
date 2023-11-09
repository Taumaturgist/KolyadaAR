using ARCarols.Scripts.Character.Config;
using UnityEngine;

namespace Ar
{
    public class ArManager : MonoBehaviour
    {
        [SerializeField] private ArFaceTrackingManager _arFaceTrackingManager;
        [SerializeField] private CharacterPlaceOnSpace _characterPlaceOnSpace;
        [SerializeField] private GameObject _componentsCharacter;
        [SerializeField] private GameObject _componentsFace;
        
        public void ChangeArState(ArState arState)
        {
            switch (arState)
            {
                case ArState.Off:
                    _componentsCharacter.SetActive(false);
                    _componentsFace.SetActive(false);
                    break;
                case ArState.MaskState:
                    _componentsCharacter.SetActive(false);
                    _componentsFace.SetActive(true);
                    break;
                case ArState.SelfieState:
                    _componentsCharacter.SetActive(false);
                    _componentsFace.SetActive(true);
                    break;
                case ArState.CharacterState:
                    _componentsFace.SetActive(false);
                    _componentsCharacter.SetActive(true);
                    break;
            }
        }

        public void SetMask(MaskData mask = null)
        {
            _arFaceTrackingManager.ChangeMask(mask == null ? null : mask.Prefab);
        }

        public void SetSelfie(MaskData mask = null)
        {
            _arFaceTrackingManager.ChangeSelfie(mask == null ? null : mask.Prefab);
        }
        
        public void SetCharacterPrefab(CharacterConfig character)
        {
            _characterPlaceOnSpace.AnchorPrefab = character.CharacterArView;
        }

        public CharacterArView GetCurrentCharacter()
        {
            return _characterPlaceOnSpace.CurrentCharacterOnScene;
        }
    }
}