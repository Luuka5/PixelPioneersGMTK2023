using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombstoneController : MonoBehaviour
{
    public GameObject zombie;
    public bool walkToTheRight = true;
    public float spawnInterval = 3;
    public Vector3 offset = new Vector2(0.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    
    private IEnumerator StartSpawning()
    {
        while (true) {
            yield return new WaitForSeconds(spawnInterval);
            GameObject zombieInstance = Instantiate(zombie, transform.position + offset, Quaternion.identity);
            zombieInstance.GetComponent<ZombieController>().isDirectionRight = walkToTheRight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
