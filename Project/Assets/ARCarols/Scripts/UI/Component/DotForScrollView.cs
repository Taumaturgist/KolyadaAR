using UnityEngine;
using UnityEngine.UI;

namespace ARCarols.Scripts.UI.Component
{
    public class DotForScrollView : MonoBehaviour
    {
        [SerializeField] private Image _image;

        [SerializeField] private Color _selectColor;

        [SerializeField] private Color _unSelectColor;

        public void SetSelect(bool isSelect)
        {
            _image.color = isSelect ? _selectColor : _unSelectColor;
        }
    }
}
