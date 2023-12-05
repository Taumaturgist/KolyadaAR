using ARCarols.Scripts.UI.Animation;
using UnityEngine;

namespace ARCarols.Scripts.Character
{
    public class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private GameObject _textCharacter;

        [SerializeField] private Animator _animator;

        [SerializeField] private TypingTextAnimation _typingTextAnimation;
        
        private static readonly int IsTalk = Animator.StringToHash("isTalk");

        public bool IsTextWriting => _typingTextAnimation.IsTextWriting;

        public void SetText(string text, AudioClip audioClip)
        {
            _textCharacter.gameObject.SetActive(!string.IsNullOrEmpty(text));

            if (text != null)
            {
                _typingTextAnimation.SetText(text, audioClip);

                _animator.SetBool(IsTalk, !string.IsNullOrEmpty(text));
            }
            
        }

        public void SkipAnimation()
        {
            _typingTextAnimation.SkipAnimation();
        }
        
    }

   
}
