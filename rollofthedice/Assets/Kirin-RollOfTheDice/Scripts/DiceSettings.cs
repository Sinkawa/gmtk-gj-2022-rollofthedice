using System;
using System.Collections.Generic;
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
        [SerializeField] private EEffect _effect;
        [SerializeField] private Sprite _sprite;

        public int Value => _value;
        public EEffect Effect => _effect;
        public Sprite Sprite => _sprite;

        public enum EFaceType
        {
            OnlyDigit,
            OnlyEffect,
            Both
        }
    }
}