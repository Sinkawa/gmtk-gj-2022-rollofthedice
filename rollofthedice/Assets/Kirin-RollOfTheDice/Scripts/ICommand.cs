using System;
using UnityEngine;

namespace Kirin_RollOfTheDice.Scripts
{
    public interface ICommand
    {
    }

    public struct Move : ICommand
    {
        public Vector3 Movement;
        public EDirection Direction;
        public int Distance;

        public Move(EDirection direction, int distance)
        {
            Direction = direction;
            Distance = distance;

            Movement = Direction switch
            {
                EDirection.Up => new Vector3(0, Distance, 0),
                EDirection.Down => new Vector3(0, -Distance, 0),
                EDirection.Left => new Vector3(-Distance, 0, 0),
                EDirection.Right => new Vector3(Distance, 0, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(Direction), Direction, null)
            };
        }

        public enum EDirection
        {
            Up,
            Down,
            Left,
            Right
        }
    }

    public struct Attack : ICommand
    {
        
    }

    public struct Defend : ICommand
    {
        
    }

    public struct CastSpell : ICommand
    {
        
    }
    
    public struct UseItem : ICommand
    {
        
    }

    public struct TakeDamage : ICommand
    {
        
    }
}