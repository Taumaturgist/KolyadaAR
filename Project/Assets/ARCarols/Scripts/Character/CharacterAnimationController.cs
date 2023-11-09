using TMPro;
using UnityEngine;

namespace ARCarols.Scripts.Character
{
    public class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textComponent;

        [SerializeField] private GameObject _textCharacter;
        public void SetText(string text)
        {
            _textCharacter.gameObject.SetActive(!string.IsNullOrEmpty(text));

            _textComponent.text = text ?? "";
        }
    }
}
