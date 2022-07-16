using System;
using Kirin_RollOfTheDice.Scripts;
using Kirin_RollOfTheDice.Scripts.Enumerations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Kirin_RollOfTheDice
{
    
    [RequireComponent(typeof(RectTransform), typeof(Image), typeof(Button))]
    public class Cell : MonoBehaviour, IDropHandler
    {
        public event Action<Directions> Used;
        
        [SerializeField] private Directions _direction;
        [SerializeField] private int _usageCost = 1;
        
        private Image _image;
        private Button _button;
        private RectTransform _rectTransform;
        
        private Dice _dice;

        public bool IsActive
        {
            get => _image.enabled;
            set => _image.enabled = value;
        }

        private Dice Dice
        {
            get => _dice;
            set
            {
                _dice = value;
                
                if (_dice is not null)
                    _button.enabled = true;
            }
        }
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _image = GetComponent<Image>();
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(OnUse);
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (!IsActive || eventData.pointerDrag is null || Dice is not null) return;
            
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = _rectTransform.anchoredPosition;
            Dice = eventData.pointerDrag.GetComponent<Dice>();
        }

        private void OnUse()
        {
            Used?.Invoke(_direction);

            if (_dice.Result.Type is not Face.EFaceType.OnlyEffect && _dice.Result.Value - _usageCost == 0)
            {
                //TODO: Destroy dice;
            }
            else _dice.Spend(_usageCost);
        }
        
    }
}