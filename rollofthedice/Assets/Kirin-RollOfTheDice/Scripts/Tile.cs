using UnityEngine;

namespace Kirin_RollOfTheDice.Scripts
{
    public class Tile : MonoBehaviour
    {
        private FogState _currentFogState;

        private FogState CurrentFogState
        {
            get => _currentFogState;
            set
            {
                _currentFogState = value;
                switch (gameObject.activeSelf)
                {
                    case true when _currentFogState is FogState.Full:
                        gameObject.SetActive(false);
                        break;
                    case false:
                        gameObject.SetActive(true);
                        break;
                }
            }
        }
        
        public void FogUp()
        {
            _currentFogState = _currentFogState switch
            {
                FogState.None => FogState.Half,
                FogState.Half => FogState.Full,
                FogState.Full => FogState.Full
            };
        }

        public void FogOff()
        {
            _currentFogState = FogState.None;
        }

        private enum FogState
        {
            Full,
            Half,
            None
        }
    }
}