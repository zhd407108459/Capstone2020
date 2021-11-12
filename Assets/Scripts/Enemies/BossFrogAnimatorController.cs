using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFrogAnimatorController : MonoBehaviour
{
    public Animator animator;
    public Animator shadowAnimator;
    public GameObject brainCollider;

    public void Attack1()
    {
        animator.SetTrigger("Attack1");
        shadowAnimator.SetTrigger("Attack1");
    }

    public void Attack2()
    {
        animator.SetTrigger("Attack2");
        shadowAnimator.SetTrigger("Attack2");
    }

    public void Attack3()
    {
        animator.SetTrigger("Attack3");
        shadowAnimator.SetTrigger("Attack3");
    }

    public void Attack4()
    {
        animator.SetTrigger("Attack4");
        shadowAnimator.SetTrigger("Attack4");
    }

    public void Hurt()
    {
        animator.SetTrigger("Hurt");
        shadowAnimator.SetTrigger("Hurt");
    }

    public void StartCoolDown()
    {
        animator.SetBool("IsCoolingDown", true);
        shadowAnimator.SetBool("IsCoolingDown", true);
        brainCollider.SetActive(true);
    }

    public void EndCoolDown()
    {
        animator.SetBool("IsCoolingDown", false);
        shadowAnimator.SetBool("IsCoolingDown", false);
        brainCollider.SetActive(false);
    }
}
