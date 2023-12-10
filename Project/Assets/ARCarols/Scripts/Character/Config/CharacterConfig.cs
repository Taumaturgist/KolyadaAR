using PanelManager.Scripts.Interfaces;
using PanelManager.Scripts.Panels;
using UnityEngine;

namespace ARCarols.Scripts.Character.Config
{
    [CreateAssetMenu(menuName = "Project/Character/CharacterConfig", fileName = "Character Config", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private string _name;

        [SerializeField] private string _description;

        [SerializeField] private string _characterActionText;

        [SerializeField] private CharacterAnimationController _characterPrefab;
        
        [SerializeField] private CharacterAnimationController _characterPrefabAr;


        [SerializeField] private CharacterTextConfig _characterTextConfig;

        [SerializeField] private ViewBase _panelForCharacterEvent;

        [SerializeField] private MaskData _selfieData;

        public MaskData SelfieData => _selfieData;

        public CharacterAnimationController CharacterPrefabAr => _characterPrefabAr;
        public string Name => _name;

        public string Description => _description;

        public string CharacterActionText => _characterActionText;

        public CharacterAnimationController IconPrefab => _characterPrefab;

        public CharacterTextConfig CharacterTextConfig => _characterTextConfig;

        public IView PanelForCharacterEvent => _panelForCharacterEvent;
    }
}