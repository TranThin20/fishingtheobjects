using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMove : MonoBehaviour
{
    public float moveSpeed = 2f;   
    public float moveDistance = 0.1f; 

    private Vector2 startPos;
    private Vector2 targetPos;
    private bool isMovingRight = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector2(moveDistance, 0);
    }

    void FixedUpdate()
    {
        // len xuong
        float yOffset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = startPos + new Vector2(0, yOffset);

        // trai phai
        if (isMovingRight)
        {
            transform.Translate(Vector2.right * moveSpeed  * Time.deltaTime);
            if (transform.position.x >= targetPos.x)
                isMovingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= startPos.x)
                isMovingRight = true;
        }
    }
}
