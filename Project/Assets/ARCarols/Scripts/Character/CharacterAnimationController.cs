using ARCarols.Scripts.UI.Animation;
using UnityEngine;

namespace ARCarols.Scripts.Character
{
    public class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private GameObject _textCharacter;

        [SerializeField] private Animator _animator;

        [SerializeField] private TypingTextAnimation _typingTextAnimation;
        
        public bool IsTextWriting => _typingTextAnimation.IsTextWriting;

        public void SetText(string text, AudioClip audioClip)
        {
            _textCharacter.gameObject.SetActive(!string.IsNullOrEmpty(text));

            _typingTextAnimation.SetText(text, audioClip);

            _animator.SetBool("isTalk", !string.IsNullOrEmpty(text));
        }

        public void SkipAnimation()
        {
            _typingTextAnimation.SkipAnimation();
        }
        
    }

   
}
