using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    public static CatAnimation instance;
    SkeletonAnimation skeleton;
    private void Awake()
    {
        instance = this;
        skeleton = GetComponent<SkeletonAnimation>();
    }

    public void SetAnimationWin()
    {
        skeleton.AnimationState.SetAnimation(0, "Ending", false);
    }
    public void SetAnimationHural()
    {
        skeleton.AnimationState.SetAnimation(0, "Bien mat", true);
    }

}
