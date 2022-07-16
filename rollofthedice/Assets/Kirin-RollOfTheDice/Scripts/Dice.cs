using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kirin_RollOfTheDice.Scripts
{
    public class Dice : MonoBehaviour
    {
        [SerializeField] private DiceSettings _diceSettings;
        [SerializeField] private int _dimensions;

        [SerializeField] private GameObject _result;
        [SerializeField] private Image _resultSprite;

        [SerializeField] private GameObject _unwrap;
        [SerializeField] private List<Image> _unwrapSprites;

        private List<Face> _faces;

        public Face Result
        {
            get; private set;
        }

        public void Generate()
        {
            _faces = new List<Face>(_dimensions);

            for (int i = 0, j = _dimensions / 2; i < _dimensions / 2; i++, j++)
            {
                _faces[i] = _diceSettings.DigitFaces.GetRandomItem();
                
                _faces[j] = _diceSettings.DigitFaces.Find(item =>
                    item.Value == (_diceSettings.DigitFaces.Count + 1) - _faces[i].Value);
                
                _unwrapSprites[i].sprite = _faces[i].Sprite;
                _unwrapSprites[j].sprite = _faces[j].Sprite;
            }
        }

        public void GetResult()
        {
            Result = _faces.GetRandomItem();
            _result.SetActive(true);
            _unwrap.SetActive(false);
        }

        public void Unwrap()
        {
            _result.SetActive(false);
            _unwrap.SetActive(true);    
        }

        public void Spend(int usageCost = 1)
        {
            Result = _diceSettings.DigitFaces.Find(item => item.Value == Result.Value - usageCost);
        }
        
    }
}