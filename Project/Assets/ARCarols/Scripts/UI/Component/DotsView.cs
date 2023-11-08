using System.Collections.Generic;
using UnityEngine;

namespace ARCarols.Scripts.UI.Component
{
    public class DotsView : MonoBehaviour
    {
        [SerializeField] private DotForScrollView _dotPrefab;

        [SerializeField] private Transform _dotSpawnPoint;

        private List<DotForScrollView> _dotCurrentDot = new();

        public void Init(int countDots)
        {
            for (int i = 0; i < countDots; i++)
            {
                var dot = Instantiate(_dotPrefab, _dotSpawnPoint);

                dot.SetSelect(false);
                
                _dotCurrentDot.Add(dot);
            }
            
            _dotCurrentDot[0].SetSelect(true);
        }

        public void SetSelectDot(int numberDot)
        {
            for (int i = 0; i < _dotCurrentDot.Count; i++)
            {
                _dotCurrentDot[i].SetSelect(i == numberDot);
            }
        }

        public void ClearDots()
        {
            for (int i = 0; i < _dotCurrentDot.Count; i++)
            {
                Destroy(_dotCurrentDot[i].gameObject);
            }
            
            _dotCurrentDot.Clear();
        }
    }
}
