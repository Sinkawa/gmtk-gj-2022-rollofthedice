using System;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public void Move(EMoveDirection direction, int distance)
    {
        var directionVector = direction switch
        {
            EMoveDirection.Up => new Vector3(0, 1, 0), 
            EMoveDirection.Down => new Vector3(0, -1, 0),
            EMoveDirection.Left => new Vector3(-1, 0, 0),
            EMoveDirection.Right => new Vector3(1, 0, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };

        transform.position += distance * directionVector;
    }
    
    

    public enum EMoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}
