using System;
using ARCarols.Scripts.Data.Interface;
using UnityEngine;

namespace ARCarols.Scripts.Data
{
    [Serializable]
    public class CharacterData : IData
    {
       [SerializeField] public bool IsCompletedMonologue;
    }
}