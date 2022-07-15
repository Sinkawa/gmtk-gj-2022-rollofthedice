using System.Collections.Generic;
using DG.Tweening;
using Kirin_RollOfTheDice.Scripts;
using UnityEngine;

using Direction = Kirin_RollOfTheDice.Scripts.Move.EDirection;

public class Hero : MonoBehaviour
{
    [SerializeField, Range(1, 20)] private int _health;
    
    [SerializeField, Range(0f, 2f)] private float _moveDuration;

    private Queue<ICommand> _commands = new();

    private bool _isFree = true;

    private void Update()
    {
        if (_isFree && _commands.Count != 0)
        {
            DoCommand();
        }
    }
    
    public void Command(ICommand command)
    {
        _commands.Enqueue(command);
    }

    private void DoCommand()
    {
        _isFree = false;
        var command = _commands.Dequeue();
        switch (command)
        {
            case Move move:
                Move(move.Movement);
                break;
            default:
                _isFree = true;
                break;
        }
    }

    private void OnCommandComplete()
    {
        _isFree = true;
    }
    
    private void Move(Vector3 movement)
    { 
        transform.DOMove(transform.position + movement, _moveDuration).SetEase(Ease.InOutQuint).OnComplete(OnCommandComplete);
    }

}
