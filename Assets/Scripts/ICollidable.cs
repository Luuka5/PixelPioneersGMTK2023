using System;
using Unity;
using UnityEngine;

public interface ICollidable
{
    public void CollisionDetected(Collision2D collision);
    public void CollisionExited();
}

