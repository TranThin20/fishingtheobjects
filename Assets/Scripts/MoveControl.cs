using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : Move
{
    protected float moveSpeed;
    protected Vector3 targetPosition;
    protected float moveTime;
    protected float delayTime;
    protected bool canMove;
    protected float startTime;
    

    protected override void Start()
    {
        canMove = false;
    }

    protected override void Update()
    {
        if (canMove && Time.time - startTime >= delayTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                canMove = false;
            }
        }
    }


}
