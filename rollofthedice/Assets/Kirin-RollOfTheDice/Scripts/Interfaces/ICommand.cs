using Kirin_RollOfTheDice.Scripts.Enumerations;

namespace Kirin_RollOfTheDice.Scripts.Interfaces
{
    public interface ICommand
    {
        
    }

    public struct Move : ICommand
    {
        public readonly Directions.EDirections Direction;

        public readonly ICommand Other;
        
        public Move(Directions.EDirections direction, ICommand other = null)
        {
            Direction = direction;
            Other = other;
        }
    }

    public struct TakeDamage : ICommand
    {
        public readonly int Damage;
        
        public TakeDamage(int damage)
        {
            Damage = damage;
        }
    }
}