using ARCarols.Scripts.Character.Config;
using UnityEngine;

namespace ARCarols.Scripts.Character.Demo
{
    public class CharacterTextTest : MonoBehaviour
    {
        [SerializeField] private CharacterAnimationController _characterAnimationController;

        [SerializeField] private CharacterTextConfig _characterTextConfig;
        
        private int _currentMonologueIndex = 0;

        public void EditMonologueIndex(int value)
        {
            if (_characterAnimationController.IsTextWriting)
            {
                _characterAnimationController.SkipAnimation();
                return;
            }

            _currentMonologueIndex += value;

            SetMonologueOnScene();
        }


        private void SetCharacterOnScene(CharacterAnimationController characterAnimationController)
        {
            _characterAnimationController = characterAnimationController;

            SetMonologueOnScene();
        }

        private void SetMonologueOnScene()
        {
            if (_characterAnimationController == null)
            {
                Debug.LogError("No Character On AR Scene");
                return;
            }
            

            var monologue = _characterTextConfig.CharacterTextProviders[_currentMonologueIndex];

            Debug.Log("textMonologue: " + monologue.Text);
            

            _characterAnimationController.SetText(monologue.Text, monologue.AudioClip);
        }
    }
}