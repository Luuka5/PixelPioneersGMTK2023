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

    public SpriteRenderer E_Button;
    public Sprite ButtonOn;
    public Sprite ButtonOff;

    public static bool currentlyInDarkTheme = false;

    private SpriteRenderer refToChild;

    public bool isToggled = false;

    public bool PlayerNear = false;

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

        if(PlayerNear == true)
        {
            if (Input.GetButtonDown("Interact"))
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
        

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "PlayerFlight" || collision.name == "PlayerMovement")
        {
            E_Button.sprite = ButtonOn;
            PlayerNear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "PlayerFlight" || collision.name == "PlayerMovement")
        {
            E_Button.sprite = ButtonOff;
            PlayerNear = false;
    
        }
    }
}
