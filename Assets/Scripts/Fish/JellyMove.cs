using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMove : Move
{
    private float moveSpeed = 0.1f;
    bool moveUp = true;
    protected override void Update()
    {
        base.Update();
        if (moveUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        if (transform.position.y >= -6f && moveUp)
        {
            moveUp = false;
        }
        if (transform.position.x < -12f && !moveUp)
        {
            moveUp = true;
        }
    }
}   
