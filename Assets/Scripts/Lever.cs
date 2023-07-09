using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

   public List<Door> ConnectedDoors;
    private bool interacted = false;

    public GameObject Untoggled;
    public GameObject Toggled;

    public Sprite LightTheme;
    public Sprite DarkTheme;


    public static bool currentlyInDarkTheme = false;

    private SpriteRenderer refToChild;

    public bool isToggled = false;

    private void Start()
    {
        List<SpriteRenderer> children = new List<SpriteRenderer>();
        GetComponentsInChildren<SpriteRenderer>(children);
        foreach (var item in children)
        {
            if (item.gameObject.name == "base")
                refToChild = item;
        }
      
    }

    private void Update()
    {
        if (currentlyInDarkTheme)
        {
            refToChild.sprite = DarkTheme;

       

        }
        else
        {
            refToChild.sprite = LightTheme;
  
        }

    }

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
