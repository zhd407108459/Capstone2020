using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishAnimatorController : MonoBehaviour
{
    public Animator animator;
    private bool isReleasingSkill;

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
        if (!isReleasingSkill)
        {
            animator.SetTrigger("Hurt");
        }
        else
        {
            Frawn();
        }
    }

    public void StartSkill()
    {
        animator.SetBool("IsReleasingSkill", true);
        isReleasingSkill = true;
    }

    public void EndSkill()
    {
        animator.SetBool("IsReleasingSkill", false);
        isReleasingSkill = false;
    }

    public void Frawn()
    {
        animator.SetTrigger("Frawn");
    }

    public void Reset()
    {
        EndSkill();
    }

}
