using ARCarols.Scripts.Character.Config;
using DG.Tweening;
using PanelManager.Scripts.Panels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Panels
{
    public class YagaActionView : ViewBase
    {
        [SerializeField] private CharacterTextConfig _characterTextConfig;

        [SerializeField] private TMP_Text _answerText;

        [SerializeField] private Button _closeButton;

        [SerializeField] private Button _startAction;

        [Header("Animation")] [SerializeField] private Image _appleSprite;

        [SerializeField] private Image _plateDownSprite;

        [SerializeField] private Transform _rotateObject;

        [SerializeField] private Transform _appleObject;

        [SerializeField] private int _countOfTurns = 1;

        [SerializeField] private float _durationAnimation = 2;

        public override PanelType PanelType => PanelType.Screen;

        public override bool RememberInHistory => false;

        private Sequence _sequence;

        private bool _isStarted;

        protected override void OnInitialize()
        {
            base.OnInitialize();
            
            _closeButton.onClick.AddListener(() => _panelManager.OpenPanel<CharacterActionsView>());
            
            _startAction.onClick.AddListener(StartAnimation);
        }
        

        private void ClearAnimation()
        {
            _sequence.Kill();
        }


        private void GetRandomText()
        {
            _answerText.text = _characterTextConfig.TextList[Random.Range(0, _characterTextConfig.TextList.Count)];
        }

        private void StartAnimation()
        {
            if (_isStarted)
            {
                return;
            }

            GetRandomText();

            _closeButton.interactable = false;
            
            _isStarted = true;

            _rotateObject.eulerAngles = Vector3.zero;

            _appleObject.eulerAngles = Vector3.zero;

            _appleSprite.color = Color.white;

            _plateDownSprite.color = Color.white;


            _sequence = DOTween.Sequence();

            _sequence.Append(
                    _appleObject
                        .DOLocalRotate(new Vector3(0, 0, 360), _durationAnimation, RotateMode.FastBeyond360)
                        .SetLoops(_countOfTurns, LoopType.Incremental)
                        .SetRelative()
                        .SetEase(Ease.Linear))
                .Join(
                    _rotateObject
                        .DOLocalRotate(new Vector3(0, 0, 360), _durationAnimation, RotateMode.FastBeyond360)
                        .SetLoops(_countOfTurns, LoopType.Incremental)
                        .SetRelative()
                        .SetEase(Ease.Linear))
                .Join(
                    _rotateObject
                        .DOScale(new Vector3(0.8f, 0.8f, 0.8f), _durationAnimation)
                        .SetLoops(_countOfTurns, LoopType.Yoyo)
                        .SetEase(Ease.Linear))
                .Join(
                    _appleObject
                        .DOScale(new Vector3(1.2f, 1.2f, 1.2f), _durationAnimation)
                        .SetLoops(_countOfTurns, LoopType.Yoyo)
                        .SetEase(Ease.Linear))
                .Join(
                    _appleSprite
                        .DOFade(0, _durationAnimation)
                        .SetEase(Ease.InExpo))
                .Join(
                    _plateDownSprite
                        .DOFade(0, _durationAnimation)
                        .SetEase(Ease.InExpo))
                .OnComplete(OnAnimationEnd);
        }


        private void OnAnimationEnd()
        {
            _isStarted = false;

            _closeButton.interactable = true;
            
            ClearAnimation();
        }
    }
}