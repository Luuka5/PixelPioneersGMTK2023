using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void MenuStart()
    {
        SceneManager.LoadScene("Level04");
    }


    public  void MenuExit()
    {
       Application.Quit();
    }


}
