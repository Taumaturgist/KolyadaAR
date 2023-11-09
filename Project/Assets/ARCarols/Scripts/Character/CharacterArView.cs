using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterArView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textComponent;
    [SerializeField] private Image _image;

    public void SetText(string text)
    {
        _textComponent.text = text ?? "";
    }

    public void SetCharacterSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
    
}
