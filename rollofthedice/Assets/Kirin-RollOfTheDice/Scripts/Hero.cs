using UnityEngine;

namespace Kirin_RollOfTheDice.Scripts
{
    public class Hero : Entity
    {
        [SerializeField] private int _viewDistance;

        public int ViewDistance => _viewDistance;
    }
}