using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Kirin_RollOfTheDice.Scripts
{
    public class DicePool : MonoBehaviour
    {
        [SerializeField] private float _moveDuration;
        
        private List<Dice> _dices;
        
        private GameObject GetRandom()
        {
            var dice = _dices.GetRandomItem();
            dice.GetResult();
            return dice.gameObject;
        }

        private void Add(Dice dice)
        {
            _dices.Add(dice);
            dice.transform.DOMove(transform.position, _moveDuration).SetEase(Ease.InQuart);
        }
        
    }
}