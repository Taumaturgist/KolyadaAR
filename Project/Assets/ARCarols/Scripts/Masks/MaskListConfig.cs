using System.Collections.Generic;
using UnityEngine;

namespace ARCarols.Scripts.Masks
{
    [CreateAssetMenu(fileName = "MaskListConfig", menuName = "Project/Mask/MaskListConfig")]
    public class MaskListConfig : ScriptableObject
    {
        [SerializeField] private List<MaskData> _masksData;

        public List<MaskData> MasksData => _masksData;
    }
}
