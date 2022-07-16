using System;
using System.Collections.Generic;
using DG.Tweening;
using Kirin_RollOfTheDice.Scripts.Enumerations;
using Kirin_RollOfTheDice.Scripts.Interfaces;
using UnityEngine;

namespace Kirin_RollOfTheDice.Scripts
{
    public class Entity : MonoBehaviour, ICommandable
    {
        [SerializeField, Range(0, 20)] private int _health;

        private Room _currentRoom;
        
        #region ICommandable

        public event Action<ICommand> CommandCompleted;
        
        private Queue<ICommand> _commandQueue = new();
        private ICommand _commandInProcess;

        public void Command(ICommand command)
        {
            _commandQueue.Enqueue(command);
        }

        private void DoCommand(ICommand command = null)
        {
            if (command == null)
                _commandInProcess = _commandQueue.Dequeue();
            else
                _commandInProcess = command;
            
            switch (_commandInProcess)
            {
                case Move move:
                    DoMove(move);
                    break;
                case TakeDamage takeDamage:
                    ApplyDamage(takeDamage);
                    break;
            }
        }

        private void OnCommandComplete()
        {
            CommandCompleted?.Invoke(_commandInProcess);
            _commandInProcess = null;
        }

        #endregion
        
        #region Actions

        [Header("Actions")] 
        [SerializeField] private float _moveDuration = 0.65f;
        
        private void DoMove(Move move)
        {
            var newPosition = transform.position + Directions.ToVector3(move.Direction);

            if (_currentRoom.GetAtPosition(newPosition) is null)
                transform.DOMove(newPosition, _moveDuration).SetEase(Ease.InOutQuint).OnComplete(OnCommandComplete);
            else if (move.Other is not null)
                DoCommand(move.Other);
        }

        private void ApplyDamage(TakeDamage takeDamage)
        {
            _health -= takeDamage.Damage;

            if (_health <= 0)
                _health = 0;
            
            OnCommandComplete();
        }
        
        #endregion
        
        private void Update()
        {
            if (_commandInProcess is not null && _commandQueue.Count > 0)
            {
                DoCommand();
            }
        }
    }
}