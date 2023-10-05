using System.Diagnostics;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectControll : MonoBehaviour
{
    public static ObjectControll instance;

    private void Awake()
    {
        instance = this;
    }
    private void OnMouseDown()
    {
        if (!HookControll.instance.isSelectItem)
        {
            SoundManager.instance.StopSound();
            Vector2 targetPosition = transform.position;
            HookControll.instance.MoveToTarget(targetPosition);
            HookControll.instance.isSelectItem = true;
        }
    }


}
