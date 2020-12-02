using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class SkeletonSmart : Skeleton
{
    public override void Move()
    {
        base.Move();
        // Posición del player con la Y del enemigo. Para evitar que el enemigo se incline al estar muy cerca del player
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        
        if (DistanceToPlayer() <= followingDistance)
        {
            transform.LookAt(target);
            //currentSpeed = speed * increaseSpeed;
        }
    }
}
