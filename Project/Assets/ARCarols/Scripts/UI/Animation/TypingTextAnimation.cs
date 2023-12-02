using System.Collections;
using TMPro;
using UnityEngine;

namespace ARCarols.Scripts.UI.Animation
{
    public class TypingTextAnimation : MonoBehaviour 
    {
        [SerializeField] private TMP_Text _textComponent;

        [SerializeField] private AudioSource _audioSource;

        public bool IsTextWriting => _isTextWriting;
       
        private const float TYPING_SPEED_CONST = 0.3f;
        
        private const float TYPING_SPEED_OFFSET =  0.01f;

        private string _writingText;

        private bool _isTextWriting;
        
        public void SetText(string text, AudioClip audioClip)
        {
            float typingSpeed = TYPING_SPEED_CONST;
            
            if (audioClip != null)
            {
                typingSpeed = (audioClip.length / text.Length) - TYPING_SPEED_OFFSET;

                _audioSource.clip = audioClip;
                
                _audioSource.Play();
            }

            _writingText = text;
            
            StartCoroutine(TypeText(text, typingSpeed));
        }

        public void SkipAnimation()
        {
            _audioSource.Stop();

            _isTextWriting = false;
            
            StopAllCoroutines();
            
            _textComponent.text = _writingText;
        }
        
        private IEnumerator TypeText(string fullText, float speed)
        {
            _isTextWriting = true;
            
            _textComponent.text = ""; // Очистка текста перед началом

            foreach (char letter in fullText)
            {
                _textComponent.text += letter; // Добавление буквы к тексту
                yield return new WaitForSeconds(speed); // Ожидание следующей буквы
            }
            
            _isTextWriting = false;
            
            _textComponent.text = _writingText;
        }
    }
    
}