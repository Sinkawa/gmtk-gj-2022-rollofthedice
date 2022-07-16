using System;
using UnityEngine;

namespace Kirin_RollOfTheDice.Scripts.Enumerations
{
    
    public class Directions
    {
        public enum EDirections
        {
            UpLeft,
            Up,
            UpRight,
            Left,
            None,
            Right,
            DownLeft,
            Down,
            DownRight
        }
        
        public static Vector3 ToVector3(EDirections direction)
        {
            return direction switch
            {
                EDirections.UpLeft => new Vector3(-1, 1, 0),
                EDirections.Up => new Vector3(0, 1, 0),
                EDirections.UpRight => new Vector3(1, 1, 0),
                EDirections.Left => new Vector3(-1, 0, 0),
                EDirections.None => new Vector3(0, 0, 0),
                EDirections.Right => new Vector3(1, 0, 0),
                EDirections.DownLeft => new Vector3(-1, -1, 0),
                EDirections.Down => new Vector3(0, -1, 0),
                EDirections.DownRight => new Vector3(1, -1, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }    
    }
    

}