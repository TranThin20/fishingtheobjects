using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : Move
{
    [SerializeField] private float moveSpeed; 
    private bool moveRight = true; 

    protected override void Update()
    {
        base.Update();
        if (moveRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(-Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (transform.position.x > 6 && moveRight)
        {
            moveRight = false;
        }
        else if (transform.position.x < -6 && !moveRight)
        {
            moveRight = true;
        }
    }
}
