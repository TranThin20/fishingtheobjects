using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : Move
{
    public static CloudMove instance;
    public float moveSpeed = 1.0f;

    protected override void Awake()
    {
        instance = this;
    }
    protected override void Update()
    {
        base.Update();
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
