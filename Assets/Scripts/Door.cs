using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum OpeningPosition
{
    Up,
    Down,
    Left,
    Right
}


public class Door : MonoBehaviour
{
    public OpeningPosition openingPosition;
    // only used for starting definition - to toggle use debug toggle 
    public bool isOpened;
    public float howFar;

    public bool debugToggle = false;

    private void Update()
    {
        if (debugToggle)
        {
            ChangeDoor();
            debugToggle = false;

        }

    }




    public void ChangeDoor()
    {
        float targetX = gameObject.transform.position.x;
        float targetY = gameObject.transform.position.y;
        switch (openingPosition)
        {
            case OpeningPosition.Up:
                targetY = isOpened ? targetY - howFar : targetY + howFar;


                break;
            case OpeningPosition.Down:
                targetY = isOpened ? targetY + howFar : targetY - howFar;
                break;
            case OpeningPosition.Left:

                targetX = isOpened ? targetX + howFar : targetX - howFar;

                break;
            case OpeningPosition.Right:
                targetX = isOpened ? targetX - howFar : targetX + howFar;
                break;
            default:
                break;
        }

        Vector2 targetPos = new Vector2(targetX, targetY);
        gameObject.transform.position = targetPos;

        isOpened = !isOpened;
    }
}
