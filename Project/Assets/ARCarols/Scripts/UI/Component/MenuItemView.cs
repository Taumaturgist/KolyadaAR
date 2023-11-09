using TMPro;
using UnityEngine;

namespace ARCarols.Scripts.UI.Component
{
    public class MenuItemView : MonoBehaviour
    {
        [SerializeField] private Transform _iconParante;
    
        [SerializeField] private TMP_Text _name;
    
        [SerializeField] private TMP_Text _description;

        public void SetData(GameObject _iconGO, string name, string descritpion)
        {
            Instantiate(_iconGO, _iconParante);

            _name.text = name;

            _description.text = descritpion;
        }
    }
}
