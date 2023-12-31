using System.Collections.Generic;
using ARCarols.Scripts.Character.Provider;
using UnityEngine;

namespace ARCarols.Scripts.Character.Config
{
    [CreateAssetMenu(menuName = "Project/Character/CharacterTextConfig", fileName = "Character Text Config", order = 0)]
    public class CharacterTextConfig : ScriptableObject
    {
        [SerializeField] private List<CharacterTextProvider> _characterTextProviders;

        public List<CharacterTextProvider> CharacterTextProviders => _characterTextProviders;
    }
}
