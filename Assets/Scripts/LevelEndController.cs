using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{
    public string nextLevelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
            SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
        }
    }
}
