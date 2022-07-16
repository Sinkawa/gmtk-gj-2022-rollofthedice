using System;
using System.Collections.Generic;
using Kirin_RollOfTheDice.Scripts.Enumerations;
using UnityEngine;

namespace Kirin_RollOfTheDice.Scripts
{
    [CreateAssetMenu(fileName = "DiceSettings", menuName = "Dices", order = 0)]
    public class DiceSettings : ScriptableObject
    {
        [SerializeField] private List<Face> _digitFaces;
        [SerializeField] private List<Face> _effectFaces;

        public List<Face> DigitFaces => _digitFaces;
        public List<Face> EffectFaces => _effectFaces;
    }

    [Serializable]
    public class Face
    {
        [SerializeField] private EFaceType _type;
        
        [SerializeField] private int _value;
        [SerializeField] private DiceEffects _effect;
        [SerializeField] private Sprite _sprite;

        public EFaceType Type => _type;
        public int Value => _value;
        public DiceEffects Effect => _effect;
        public Sprite Sprite => _sprite;

        public enum EFaceType
        {
            OnlyDigit,
            OnlyEffect,
            Both
        }
    }
}