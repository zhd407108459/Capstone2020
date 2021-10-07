using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaceExpressionController : MonoBehaviour
{
    public enum FaceExpressionEventType
    {
        Neutral,
        Hurt,
        Speachless,
        Shock,
        Happy,
        Confused,
        Annoyed,
        Blink
    }

    public void Neutral()
    {
        SetFace(FaceExpressionEventType.Neutral);
    }

    public void Hurt()
    {
        SetFace(FaceExpressionEventType.Hurt);
    }

    public void Speachless()
    {
        SetFace(FaceExpressionEventType.Speachless);
    }

    public void Shock()
    {
        SetFace(FaceExpressionEventType.Shock);
    }

    public void Happy()
    {
        SetFace(FaceExpressionEventType.Happy);
    }

    public void Confused()
    {
        SetFace(FaceExpressionEventType.Confused);
    }

    public void Annoyed()
    {
        SetFace(FaceExpressionEventType.Annoyed);
    }

    public void Blink()
    {
        SetFace(FaceExpressionEventType.Blink);
    }

    public void SetFace(FaceExpressionEventType type)
    {
        Animator animator = GetComponent<PlayerGridMovement>().animator;
        if(type == FaceExpressionEventType.Neutral)
        {
            animator.SetBool("Hurt", false);
            animator.SetBool("Speachless", false);
            animator.SetBool("Shock", false);
            animator.SetBool("Happy", false);
            animator.SetBool("Confused", false);
            animator.SetBool("Annoyed", false);
            animator.SetBool("Blink", false);
        }
        if (type == FaceExpressionEventType.Hurt)
        {
            animator.SetBool("Speachless", false);
            animator.SetBool("Shock", false);
            animator.SetBool("Happy", false);
            animator.SetBool("Confused", false);
            animator.SetBool("Annoyed", false);
            animator.SetBool("Blink", false);
            animator.SetBool("Hurt", true);
        }
        if (type == FaceExpressionEventType.Speachless)
        {
            animator.SetBool("Hurt", false);
            animator.SetBool("Shock", false);
            animator.SetBool("Happy", false);
            animator.SetBool("Confused", false);
            animator.SetBool("Annoyed", false);
            animator.SetBool("Blink", false);
            animator.SetBool("Speachless", true);
        }
        if (type == FaceExpressionEventType.Shock)
        {
            animator.SetBool("Hurt", false);
            animator.SetBool("Speachless", false);
            animator.SetBool("Happy", false);
            animator.SetBool("Confused", false);
            animator.SetBool("Annoyed", false);
            animator.SetBool("Blink", false);
            animator.SetBool("Shock", true);
        }
        if (type == FaceExpressionEventType.Happy)
        {
            animator.SetBool("Hurt", false);
            animator.SetBool("Speachless", false);
            animator.SetBool("Shock", false);
            animator.SetBool("Confused", false);
            animator.SetBool("Annoyed", false);
            animator.SetBool("Blink", false);
            animator.SetBool("Happy", true);
        }
        if (type == FaceExpressionEventType.Confused)
        {
            animator.SetBool("Hurt", false);
            animator.SetBool("Speachless", false);
            animator.SetBool("Shock", false);
            animator.SetBool("Happy", false);
            animator.SetBool("Annoyed", false);
            animator.SetBool("Blink", false);
            animator.SetBool("Confused", true);
        }
        if (type == FaceExpressionEventType.Annoyed)
        {
            animator.SetBool("Hurt", false);
            animator.SetBool("Speachless", false);
            animator.SetBool("Shock", false);
            animator.SetBool("Happy", false);
            animator.SetBool("Confused", false);
            animator.SetBool("Blink", false);
            animator.SetBool("Annoyed", true);
        }
        if (type == FaceExpressionEventType.Blink)
        {
            animator.SetBool("Hurt", false);
            animator.SetBool("Speachless", false);
            animator.SetBool("Shock", false);
            animator.SetBool("Happy", false);
            animator.SetBool("Confused", false);
            animator.SetBool("Annoyed", false);
            animator.SetBool("Blink", true);
        }
    }

    public void EnableEmptyHand()
    {
        Animator animator = GetComponent<PlayerGridMovement>().animator;
        animator.SetBool("EmptyHand", true);
    }

    public void DisableEmptyHand()
    {
        Animator animator = GetComponent<PlayerGridMovement>().animator;
        animator.SetBool("EmptyHand", false);
    }
}
