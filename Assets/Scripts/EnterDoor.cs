using UnityEngine;
using UnityEngine.Audio;

public class EnterDoor : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject DoorOutside;
    [SerializeField] private GameObject DoorInside;
    private Vector3 PositionDoorOutside;
    private Vector3 PositionDoorInside;

    [SerializeField] bool inTrigger = false;
    private void Start()
    {
        PositionDoorInside = DoorInside.transform.position;
        PositionDoorOutside = DoorOutside.transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown("e") && inTrigger == true)
        {
            Debug.Log("DoorOutside is "+ PositionDoorOutside);
            Debug.Log("DoorInside is"+ PositionDoorInside);
            Debug.Log("pressed E in door");

            Player.transform.position = PositionDoorOutside;
            //teleport
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        inTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        inTrigger = false;
    }

}
