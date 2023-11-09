using System.Collections;
using UnityEngine;

namespace Ar
{
    public class ArManager : MonoBehaviour
    {
        [SerializeField] private ArFaceTrackingManager _arFaceTrackingManager;
        [SerializeField] private CharacterPlaceOnSpace _characterPlaceOnSpace;
        [SerializeField] private GameObject _componentsCharacter;
        [SerializeField] private GameObject _componentsFace;
        [SerializeField] private MaskData _testMaskData;
        [SerializeField] private GameObject _testSelfie;


        private void Start()
        {
            StartCoroutine(Test());
        }

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
                    SetMask(_testMaskData);
                    break;
                case ArState.SelfieState:
                    _componentsCharacter.SetActive(false);
                    _componentsFace.SetActive(true);
                    SetSelfie(_testSelfie);
                    break;
                case ArState.CharacterState:
                    _componentsFace.SetActive(false);
                    _componentsCharacter.SetActive(true);
                    break;
            }
        }

        public void SetMask(MaskData maskData)
        {
            _arFaceTrackingManager.ChangeMask(maskData);
        }

        public void SetSelfie(GameObject character)
        {
            _arFaceTrackingManager.ChangeSelfie(character);
        }

        private IEnumerator Test()
        {
            ChangeArState(ArState.Off);
            yield return new WaitForSeconds(1f);
            ChangeArState(ArState.MaskState);
            yield return new WaitForSeconds(10f);
            ChangeArState(ArState.CharacterState);
            yield return new WaitForSeconds(10f);
            ChangeArState(ArState.SelfieState);
        }
    }
}