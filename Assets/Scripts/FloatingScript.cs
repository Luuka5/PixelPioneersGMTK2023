using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    //Variables
    public float range;
    public float wobbleSpeed;
    public Vector3 Rotation;
    private Vector3 startPosition;
    private float elapsedFrames = 0;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FloatMethod();
    }

    public void FloatMethod()
    {
        elapsedFrames += 0.1f;
        transform.position = new Vector3(startPosition.x, startPosition.y + Mathf.Sin(elapsedFrames * wobbleSpeed) * range,
            startPosition.z);
        transform.Rotate(Rotation);

        if (elapsedFrames >= float.MaxValue)
        {
            elapsedFrames = 0;
        }
    }
}
