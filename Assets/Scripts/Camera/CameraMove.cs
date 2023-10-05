using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CameraMove : MoveControl
{
    [SerializeField] private AudioClip water;
    [SerializeField] private AudioClip hural;
    [SerializeField] private AudioClip congrats;
    private Vector3 startPosition;
    public bool canMoveUp;
    public bool canEnd = false;
    public static CameraMove instance;

    protected override void Awake()
    {

        instance = this;
    }
    protected override void Start()
    {
        base.Start();
        delayTime = 3.25f;
        moveTime = 1f;
        canMoveUp = false;
        startPosition = gameObject.transform.position;
        StartCoroutine(MoveObjectWithDelay(delayTime));
    }
    protected IEnumerator MoveObjectWithDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        canMove = true;
        targetPosition = new Vector3(0, -10, -10);
        moveSpeed = (transform.position.y - targetPosition.y) / moveTime;
        SoundManager.instance.StopSound();
        SoundManager.instance.PlaySoundOnce(water, 0.75f);
    }
    protected IEnumerator MoveToWin(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        targetPosition = startPosition;
        Debug.Log("cameramoveto: " + targetPosition);
        moveSpeed = -(transform.position.y - targetPosition.y) / moveTime;
        canMove = true;
    }

    protected override void Update()
    {
        base.Update();
        if (AddComponents.instance.win && canMoveUp && !canEnd)
        {
            Debug.Log("canMoveUp");
            StartCoroutine(MoveToWin(2.5f));
            StartCoroutine(Win());
            canMoveUp = false;         

        }
    }
    public IEnumerator Win()
    {
        yield return new WaitForSeconds(1.5f);
        CatAnimation.instance.SetAnimationWin();
        yield return new WaitForSeconds(1.5f);
        SoundManager.instance.PlaySoundOnce(congrats, 0.75f);
        yield return new WaitForSeconds(2f);
        SoundManager.instance.StopSound();
        SoundManager.instance.PlaySoundLoop(hural, 0.75f);
        CatAnimation.instance.SetAnimationHural();
        yield return new WaitForSeconds(2.5f);
        SoundManager.instance.StopSound();
        canEnd = true;
    }
}
