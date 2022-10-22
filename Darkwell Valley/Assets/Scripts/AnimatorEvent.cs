using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvent : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void DisableAnimator()
    {
        if (anim != null)
            anim.enabled = false;
    }
}
