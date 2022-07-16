using System.Collections.Generic;
using System.Linq;
using Kirin_RollOfTheDice.Scripts.Interfaces;
using UnityEngine;

namespace Kirin_RollOfTheDice.Scripts
{
    public class Room : MonoBehaviour
    {
        private Hero _hero;
        private List<Entity> _entities;
        private List<Tile> _tiles;
        
        private void Awake()
        {
            _hero = GetComponentInChildren<Hero>();
            _hero.CommandCompleted += OnHeroCommandCompleted;
            
            _entities = GetComponentsInChildren<Entity>().ToList();
            _entities.Remove(_hero);
        }

        public Entity GetAtPosition(Vector3 position)
        {
            return _entities.Find(item => Vector3.Distance(item.transform.position, position) <= 0.1f);
        }

        private void OnHeroCommandCompleted(ICommand command)
        {
            switch (command)
            {
                case Move move:
                    UpdateHierarchy();
                    UpdateFogOfWar();
                    break;
            }
        }

        private void UpdateHierarchy()
        {
            var newTile = _tiles.Find(item => Vector3.Distance(item.transform.position, _hero.transform.position) <= 0.1f);
            _hero.transform.parent = newTile.transform;

            foreach (var entity in _entities)
            {
                newTile = _tiles.Find(item => Vector3.Distance(item.transform.position, entity.transform.position) <= 0.1f);
                entity.transform.parent = newTile.transform;    
            }
        }
        
        private void UpdateFogOfWar()
        {
            foreach (var tile in _tiles)
            {
                if (Vector3.Distance(tile.transform.position, _hero.transform.position) > _hero.ViewDistance)
                {
                    tile.FogUp();
                }
                else
                {
                    tile.FogOff();
                }
            }    
        }
        
    }
}