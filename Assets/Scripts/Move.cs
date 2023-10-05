using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    //public float moveSpeed = 2.0f;
    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Start()
    {
        //For override
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void Update()
    {
        //For override
    }

    protected virtual void FixedUpdate()
    {
        //For override
    }

    protected virtual void OnEnable()
    {
        //For override
    }

    protected virtual void LoadComponents()
    {
        //For override   
    }
}
