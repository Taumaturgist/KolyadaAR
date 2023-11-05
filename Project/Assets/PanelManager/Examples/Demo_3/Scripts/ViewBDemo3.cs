using UnityEngine;
using UnityEngine.UI;

namespace BurningKnight.PanelManager.Demo_3
{
    public class ViewBDemo3 : ViewWithModelBase<PanelModel_B_Demo_3>
    {
        [SerializeField] private Text   _valueText;
        [SerializeField] private Button _backButton;
        [SerializeField] private Slider _valueSlider;

        public override PanelType PanelType         => PanelType.Screen;
        public override bool      RememberInHistory => false;

        protected override void OnInitialize()
        {
            _backButton.onClick.AddListener(Model.Back);
            _valueSlider.value = Model.MusicVolume / 100f;
            _valueSlider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            Model.MusicVolume.SetValue(Mathf.CeilToInt(value * 100));
            ShowValue();
        }

        protected override void OnOpened()
        {
            ShowValue();
        }

        protected override void OnClosed() {}

        private void ShowValue()
        {
            _valueText.text = $"Value: {Model.MusicVolume.Value}";
        }
    }
}