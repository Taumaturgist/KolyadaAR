using ARCarols.Scripts.UI.Animation;
using UnityEngine;

namespace ARCarols.Scripts.Character
{
    public class CharacterAnimationController : MonoBehaviour
    {
        [SerializeField] private GameObject _textCharacter;

        [SerializeField] private Animator _animator;

        [SerializeField] private TypingTextAnimation _typingTextAnimation;
        
        private readonly int IsTalk = Animator.StringToHash("isTalk");
        
        private readonly int IsDance = Animator.StringToHash("isDance");
        
        private readonly int OnIdle = Animator.StringToHash("OnIdle");

        public bool IsTextWriting => _typingTextAnimation.IsTextWriting;

        public void SetText(string text, AudioClip audioClip, bool useDance = false)
        {
            _textCharacter.SetActive(!string.IsNullOrEmpty(text));

            _typingTextAnimation.OnCompleteAnimation += OnCompleteAnimation;
            
            if (text != null)
            {
                _typingTextAnimation.SetText(text, audioClip);

                int animation = IsTalk;
                
                if (useDance)
                {
                    animation = IsDance;
                }
                
                _animator.SetBool(animation, !string.IsNullOrEmpty(text));
            }
            
        }

        private void OnCompleteAnimation()
        {
            _typingTextAnimation.OnCompleteAnimation -= OnCompleteAnimation;
            _animator.SetTrigger(OnIdle);
        }

        public void SkipAnimation()
        {
            _typingTextAnimation.SkipAnimation();
        }
        
    }

   
}
