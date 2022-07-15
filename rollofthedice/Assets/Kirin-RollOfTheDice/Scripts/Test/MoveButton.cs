using UnityEngine;
using UnityEngine.UI;

public class MoveButton : MonoBehaviour
{
    [SerializeField] private Hero.EMoveDirection _moveDirection;
    [SerializeField] private int _distance;
    
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        FindObjectOfType<Hero>().Move(_moveDirection, _distance);
    }

}
