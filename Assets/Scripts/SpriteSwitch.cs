using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Switches to dark theme / light theme
public class SpriteSwitch : MonoBehaviour
{

    public Sprite LightTheme;
    public Sprite DarkTheme;

    private SpriteRenderer SpriteRender;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.currentlyInDarkTheme)
        {
            SpriteRender.sprite = DarkTheme;
        }
        else
        {
            SpriteRender.sprite = LightTheme;
        }

    }
}
