using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFrogAnimatorController : MonoBehaviour
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

    public void StartCoolDown()
    {
        animator.SetBool("IsCoolingDown", true);
    }

    public void EndCoolDown()
    {
        animator.SetBool("IsCoolingDown", false);
    }
}
