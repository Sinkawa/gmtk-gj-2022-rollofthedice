using System.Collections.Generic;
using UnityEngine;

namespace Kirin_RollOfTheDice.Scripts
{
    public class Dice : MonoBehaviour
    {
        [SerializeField] private DiceSettings _diceSettings;
        
        [SerializeField] private int _dimensions = 6;
        [SerializeField] private int _maxEffects = 1;
        [SerializeField] private bool _generateEffects = false;
        [SerializeField, Range(0f, 1f)] private float _effectChance = 0.33f;


        [Header("Result")] 
        [SerializeField] private GameObject _result;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [Header("Unwrap")] 
        [SerializeField] private GameObject _unwrap;
        [SerializeField] private List<SpriteRenderer> _spriteRenderers;
        
        
        private List<Face> _faces;
        private int _effectCount;

        public void Generate()
        {
            _faces?.Clear();
            _faces = new List<Face>(_dimensions);
            _effectCount = 0;
            
            var faces = _diceSettings.DigitFaces; 
            
            for (var i = 0; i < _dimensions / 2; i++)
            {
                var face = faces.GetRandomItem();
                _faces[i] = face;
                _spriteRenderers[i].sprite = face.Sprite;

                var otherIndex = i + _dimensions / 2;
                var otherValue = faces.Count - face.Value;
                var otherFace = faces.Find(item => item.Value == otherValue);
                _faces[otherIndex] = otherFace;
                _spriteRenderers[otherIndex].sprite = face.Sprite;
            }

            if (!_generateEffects || !(Random.Range(0, 1) < _effectChance))
                return;
            
            var index = _faces.GetRandomIndex();
            _faces[index] = _diceSettings.EffectFaces.GetRandomItem();
            
            _effectCount = 1;
        }

        public void Unwrap()
        {
            _result.SetActive(false);
            _unwrap.SetActive(true);
        }
        
        public Face GetRandom()
        {
            var face = _faces.GetRandomItem();

            _spriteRenderer.sprite = face.Sprite;
            
            _result.SetActive(true);
            _unwrap.SetActive(false);
            
            return face;
        }
    }
}