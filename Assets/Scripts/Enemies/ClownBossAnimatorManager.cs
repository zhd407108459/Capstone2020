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

    public void Glitch1On()
    {
        animator.SetBool("IsGlitch1", true);
    }

    public void Glitch1Off()
    {
        animator.SetBool("IsGlitch1", false);
    }

    public void Glitch2On()
    {
        animator.SetBool("IsGlitch2", true);
    }

    public void Glitch2Off()
    {
        animator.SetBool("IsGlitch2", false);
    }

    public void Glitch3On()
    {
        animator.SetBool("IsGlitch3", true);
    }

    public void Glitch3Off()
    {
        animator.SetBool("IsGlitch3", false);
    }

    public void Reset()
    {
        if (GridManager.instance.isBoss2Phase)
        {
            animator.SetBool("IsAngry", true);
        }
        else
        {
            animator.SetBool("IsAngry", false);
        }
        animator.SetBool("IsGlitch1", false);
        animator.SetBool("IsGlitch2", false);
        animator.SetBool("IsGlitch3", false);
        animator.Play("Boss_smile", 1, 0f);
        animator.Play("Idle", 0, 0f);
    }
}
