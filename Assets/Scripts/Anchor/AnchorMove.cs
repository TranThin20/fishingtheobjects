using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AnchorMove : MoveControl
{
    [SerializeField] private AudioClip topic;
    [SerializeField] private AudioClip guiding;
    private bool isGuiding = false;
    private int numberOfItemsPicked = 0;
    private int totalItemsToPick = 4;
    public bool isStartGuid = false;
    public static AnchorMove instance;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }
    //[SerializeField] private AudioClip hook;
    protected override void Start()
    {
        delayTime = 4f;
        base.Start();
        gameObject.SetActive(false);
        moveTime = 0.75f;
        targetPosition = new Vector3(transform.position.x, -10, 0);
        moveSpeed = (transform.position.y - targetPosition.y) / moveTime;
        Invoke("DelayTimeStart", delayTime);  
    }

    private void DelayTimeStart()
    {
        canMove = true;
        gameObject.SetActive(true);
    }
    protected IEnumerator MoveObjectWithDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        canMove = true;
        gameObject.SetActive(true);
    }
    protected override void Update()
    {
        base.Update();
        if (!isGuiding && transform.position == targetPosition && !isStartGuid)
        {
            //firstGuiding
            StartCoroutine(PlayGuidingSound());
            isStartGuid = true;
        }
        if (HookControll.instance.isSelectItem == true)
        {
            Debug.Log("isSelectItem");
        }
        else if (isGuiding)
        {
            StartCoroutine(PlayGuidingRepeat());
            isGuiding = false;
        }
    }
    private IEnumerator PlayGuidingSound()
    {
        isGuiding = true;
        yield return new WaitForSeconds(0.2f);
        SoundManager.instance.PlaySoundOnce(guiding, 0.75f);
    }
    private IEnumerator PlayGuidingRepeat()
    {
        while (numberOfItemsPicked < totalItemsToPick)
        {
            Debug.Log("!isSeclectItem");
            yield return new WaitForSeconds(5f);

            if (HookControll.instance.isSelectItem)
            {
                numberOfItemsPicked++;
            }
            else
            {
                SoundManager.instance.PlaySoundOnce(guiding, 0.75f); 
            }
        }

    }
}
