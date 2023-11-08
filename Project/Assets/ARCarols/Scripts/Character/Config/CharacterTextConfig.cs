using System.Collections.Generic;
using UnityEngine;

namespace ARCarols.Scripts.Character.Config
{
    [CreateAssetMenu(menuName = "Project/Character/CharacterTextConfig", fileName = "Character Text Config", order = 0)]
    public class CharacterTextConfig : ScriptableObject
    {
        [SerializeField] private List<string> _textList;

        public List<string> TextList => _textList;
    }
}
