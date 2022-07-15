using Kirin_RollOfTheDice.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    [SerializeField] private Move.EDirection _moveDirection;
    [SerializeField] private int _distance;
    
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        FindObjectOfType<Hero>().Command(new Move(_moveDirection, _distance));
    }

}
