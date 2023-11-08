using ARCarols.Scripts.Character.Config;
using ARCarols.Scripts.UI.Configs.Base;
using UnityEngine;

namespace ARCarols.Scripts.UI.Configs
{
    [CreateAssetMenu(menuName = "Project/MenuItem/CharacterMenuItem", fileName = "Character Menu Item", order = 0)]
    public class CharacterMenuItem : MenuItemBase
    {
        [SerializeField] private CharacterConfig _characterConfig;
        
        public override string Name => _characterConfig.Name;

        public override string Description => _characterConfig.Description;

        public override GameObject IconPrefab => _characterConfig.IconPrefab.gameObject;

        public CharacterConfig CharacterConfig => _characterConfig;

    }
}
