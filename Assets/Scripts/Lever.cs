using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

   public List<Door> ConnectedDoors;
    private bool interacted = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger: " + interacted);
        if (Input.GetButtonDown("Interact"))
        {
            if(interacted == false)
            {
                foreach (var item in ConnectedDoors)
                {
                    item.ChangeDoor();
                }
                interacted = true;
            }
            
        }

        if (Input.GetButtonUp("Interact"))
        {
            interacted = false;
        }


       
    }
}
