using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

   public List<Door> ConnectedDoors;
    private bool interacted = false;

    public GameObject Untoggled;
    public GameObject Toggled;

    public bool isToggled = false;

    

    private void OnTriggerStay2D(Collider2D collision)
    {
       
        if (Input.GetButtonDown("Interact"))
        {
            if (interacted == false)
            {
                foreach (var item in ConnectedDoors)
                {
                    item.ChangeDoor();
                }
                interacted = true;

                isToggled = !isToggled;
                if (isToggled)
                {
                    Untoggled.SetActive(false);
                    Toggled.SetActive(true);
                }
                else 
                    {
                    Untoggled.SetActive(true);
                    Toggled.SetActive(false);
                }
            }
            
        }

        if (Input.GetButtonUp("Interact"))
        {
            interacted = false;
        }


       
    }
}
