using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public static bool currentlyInDarkTheme;
    public float lightThemeIntensity = 0.1f;
    //public Color lightThemeColor;
    public float darkThemeIntensity = 1f;
    //public Color darkThemeColor;
    //public bool useColor = true;

    private UnityEngine.Rendering.Universal.Light2D light2d;

    // Start is called before the first frame update
    void Start()
    {
        light2d = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyInDarkTheme) {
            Debug.Log("Lightingh ligth");
            light2d.intensity = lightThemeIntensity;
        } else {
            light2d.intensity = darkThemeIntensity;
            Debug.Log("Lightingh dark");
        }

        /*
        doesn't work for some reason
        if (useColor) {
            if (currentlyInDarkTheme) {
                light2d.color = lightThemeColor;
            } else {
                light2d.color = darkThemeColor;
            }
        }*/
    }
}
