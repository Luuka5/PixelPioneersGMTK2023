using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollider : MonoBehaviour
{
    private ICollidable ParrentCollider;
   

    public void LinkModels(ICollidable parrent)
    {
        ParrentCollider = parrent;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ParrentCollider != null && collision != null)
            ParrentCollider.CollisionDetected(collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (ParrentCollider != null)
            ParrentCollider.CollisionExited();

    }

}
