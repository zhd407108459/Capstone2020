using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownBossAnimatorManager : MonoBehaviour
{
    public Animator animator;
    public void Attack1()
    {
        animator.SetTrigger("Attack1");
    }

    public void Attack2()
    {
        animator.SetTrigger("Attack2");
    }

    public void Attack3()
    {
        animator.SetTrigger("Attack3");
    }

    public void Attack4()
    {
        animator.SetTrigger("Attack4");
    }

    public void Hurt()
    {
        animator.SetTrigger("Hurt");
    }

    public void Angry()
    {
        animator.SetBool("IsAngry", true);
    }

    public void Smile()
    {
        animator.SetBool("IsAngry", false);
    }

    public void Reset()
    {

    }
}
