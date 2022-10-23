using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvent : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        /** Uzima instancu iz GameObjecta kako se ne bi morala ručno ubacivati.*/
        anim = GetComponent<Animator>();
    }
    public void DisableAnimator()
    {
        /** Deaktivira animator
         To služi kao event u animaciji prilikom završetka.*/
        if (anim != null)
            anim.enabled = false;
    }

    public void EnableAnimator()
    {
        /**Aktivira animator
        To služi kao event u animaciji prilikom početka.*/
        if (anim != null)
            anim.enabled = true;
    }
}
