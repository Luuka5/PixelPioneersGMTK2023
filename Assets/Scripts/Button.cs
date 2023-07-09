using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public List<Door> ConnectedDoors;
    private bool isPushed = false;

    public Transform buttonCap;
    public float pushDepth;
    public Vector2 offsetPos;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isPushed == false && collision.gameObject.GetComponent<PushButtonTrigger>() != null)
        {
            foreach (var item in ConnectedDoors)
            {
                item.ChangeDoor();
            }
            
            buttonCap.localPosition = new Vector2(0, -pushDepth) + offsetPos;
            isPushed = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (isPushed == true && collision.gameObject.GetComponent<PushButtonTrigger>() != null)
        {

            foreach (var item in ConnectedDoors)
            {
                item.ChangeDoor();
            }
            
            buttonCap.localPosition = offsetPos;
            isPushed = false;
        }
    }
}
