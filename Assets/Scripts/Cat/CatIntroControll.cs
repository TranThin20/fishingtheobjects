using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CatIntroControll : MoveControl
{
    private float timeMove = 2.5f;
    private float speed;
    [SerializeField] private AudioClip intro;
    protected override void Start()
    {
        base.Start();
        targetPosition = new Vector3(0, transform.position.y, 0);
        this.speed = (targetPosition.x - transform.position.x) / timeMove;
        SoundManager.instance.PlaySoundOnce(intro, 0.25f);
    }

    protected override void Update()
    {
        base.Update();
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position.x >= targetPosition.x)
        {
            canMove = false;
            enabled = false;
        }
        
    }
}
