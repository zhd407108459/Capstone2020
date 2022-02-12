using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartyAnimationManager : MonoBehaviour
{
    public Animator animator;

    public enum MartyAnimationEventType
    {
        Idle,
        Moving,
        Dying,
        Pointing1,
        Pointing2,
        LayDown,
        Netural,
        Adore,
        Akimbo,
        Angry,
        Complacement,
        Confident,
        Confused,
        Happy,
        Sad,
        Sulk,
        Surprised,
        EmptySunGlass,
        SunGlass
    }

    public void SetIdle()
    {
        SetAnimation(MartyAnimationEventType.Idle);
    }

    public void SetMoving()
    {
        SetAnimation(MartyAnimationEventType.Moving);
    }

    public void SetDying()
    {
        SetAnimation(MartyAnimationEventType.Dying);
    }

    public void SetPointing1()
    {
        SetAnimation(MartyAnimationEventType.Pointing1);
    }

    public void SetPointing2()
    {
        SetAnimation(MartyAnimationEventType.Pointing2);
    }

    public void SetLayDown()
    {
        SetAnimation(MartyAnimationEventType.LayDown);
    }

    public void SetNetural()
    {
        SetAnimation(MartyAnimationEventType.Netural);
    }

    public void SetAdore()
    {
        SetAnimation(MartyAnimationEventType.Adore);
    }

    public void SetAkimbo()
    {
        SetAnimation(MartyAnimationEventType.Akimbo);
    }

    public void SetAngry()
    {
        SetAnimation(MartyAnimationEventType.Angry);
    }

    public void SetComplacement()
    {
        SetAnimation(MartyAnimationEventType.Complacement);
    }

    public void SetConfident()
    {
        SetAnimation(MartyAnimationEventType.Confident);
    }

    public void SetConfused()
    {
        SetAnimation(MartyAnimationEventType.Confused);
    }

    public void SetHappy()
    {
        SetAnimation(MartyAnimationEventType.Happy);
    }

    public void SetSad()
    {
        SetAnimation(MartyAnimationEventType.Sad);
    }

    public void SetSulk()
    {
        SetAnimation(MartyAnimationEventType.Sulk);
    }

    public void SetSurprised()
    {
        SetAnimation(MartyAnimationEventType.Surprised);
    }

    public void SetEmptySunGlass()
    {
        SetAnimation(MartyAnimationEventType.EmptySunGlass);
    }
    public void SetSunGlass()
    {
        SetAnimation(MartyAnimationEventType.SunGlass);
    }

    public void SetAnimation(MartyAnimationEventType type)
    {
        if(animator == null)
        {
            Debug.LogError("Animator is null!!");
            return;
        }
        if(type == MartyAnimationEventType.Idle)
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsDying", false);
            animator.SetBool("IsPointing1", false);
            animator.SetBool("IsPointing2", false);
            animator.SetBool("IsLayDown", false);
        }
        if (type == MartyAnimationEventType.Moving)
        {
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsDying", false);
            animator.SetBool("IsPointing1", false);
            animator.SetBool("IsPointing2", false);
            animator.SetBool("IsLayDown", false);
        }
        if (type == MartyAnimationEventType.Dying)
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsDying", true);
            animator.SetBool("IsPointing1", false);
            animator.SetBool("IsPointing2", false);
            animator.SetBool("IsLayDown", false);
        }
        if (type == MartyAnimationEventType.Pointing1)
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsDying", false);
            animator.SetBool("IsPointing1", true);
            animator.SetBool("IsPointing2", false);
            animator.SetBool("IsLayDown", false);
        }
        if (type == MartyAnimationEventType.Pointing2)
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsDying", false);
            animator.SetBool("IsPointing1", false);
            animator.SetBool("IsPointing2", true);
            animator.SetBool("IsLayDown", false);
        }
        if (type == MartyAnimationEventType.LayDown)
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsDying", false);
            animator.SetBool("IsPointing1", false);
            animator.SetBool("IsPointing2", false);
            animator.SetBool("IsLayDown", true);
        }

        if (type == MartyAnimationEventType.Netural)
        {
            animator.SetBool("IsAdore", false);
            animator.SetBool("IsAkimbo", false);
            animator.SetBool("IsAngry", false);
            animator.SetBool("IsComplacement", false);
            animator.SetBool("IsConfident", false);
            animator.SetBool("IsConfused", false);
            animator.SetBool("IsHappy", false);
            animator.SetBool("IsSad", false);
            animator.SetBool("IsSulk", false);
            animator.SetBool("IsSurprised", false);
        }
        if (type == MartyAnimationEventType.Adore)
        {
            animator.SetBool("IsAdore", true);
            animator.SetBool("IsAkimbo", false);
            animator.SetBool("IsAngry", false);
            animator.SetBool("IsComplacement", false);
            animator.SetBool("IsConfident", false);
            animator.SetBool("IsConfused", false);
            animator.SetBool("IsHappy", false);
            animator.SetBool("IsSad", false);
            animator.SetBool("IsSulk", false);
            animator.SetBool("IsSurprised", false);
        }
        if (type == MartyAnimationEventType.Akimbo)
        {
            animator.SetBool("IsAdore", false);
            animator.SetBool("IsAkimbo", true);
            animator.SetBool("IsAngry", false);
            animator.SetBool("IsComplacement", false);
            animator.SetBool("IsConfident", false);
            animator.SetBool("IsConfused", false);
            animator.SetBool("IsHappy", false);
            animator.SetBool("IsSad", false);
            animator.SetBool("IsSulk", false);
            animator.SetBool("IsSurprised", false);
        }
        if (type == MartyAnimationEventType.Angry)
        {
            animator.SetBool("IsAdore", false);
            animator.SetBool("IsAkimbo", false);
            animator.SetBool("IsAngry", true);
            animator.SetBool("IsComplacement", false);
            animator.SetBool("IsConfident", false);
            animator.SetBool("IsConfused", false);
            animator.SetBool("IsHappy", false);
            animator.SetBool("IsSad", false);
            animator.SetBool("IsSulk", false);
            animator.SetBool("IsSurprised", false);
        }
        if (type == MartyAnimationEventType.Complacement)
        {
            animator.SetBool("IsAdore", false);
            animator.SetBool("IsAkimbo", false);
            animator.SetBool("IsAngry", false);
            animator.SetBool("IsComplacement", true);
            animator.SetBool("IsConfident", false);
            animator.SetBool("IsConfused", false);
            animator.SetBool("IsHappy", false);
            animator.SetBool("IsSad", false);
            animator.SetBool("IsSulk", false);
            animator.SetBool("IsSurprised", false);
        }
        if (type == MartyAnimationEventType.Confident)
        {
            animator.SetBool("IsAdore", false);
            animator.SetBool("IsAkimbo", false);
            animator.SetBool("IsAngry", false);
            animator.SetBool("IsComplacement", false);
            animator.SetBool("IsConfident", true);
            animator.SetBool("IsConfused", false);
            animator.SetBool("IsHappy", false);
            animator.SetBool("IsSad", false);
            animator.SetBool("IsSulk", false);
            animator.SetBool("IsSurprised", false);
        }
        if (type == MartyAnimationEventType.Confused)
        {
            animator.SetBool("IsAdore", false);
            animator.SetBool("IsAkimbo", false);
            animator.SetBool("IsAngry", false);
            animator.SetBool("IsComplacement", false);
            animator.SetBool("IsConfident", false);
            animator.SetBool("IsConfused", true);
            animator.SetBool("IsHappy", false);
            animator.SetBool("IsSad", false);
            animator.SetBool("IsSulk", false);
            animator.SetBool("IsSurprised", false);
        }
        if (type == MartyAnimationEventType.Happy)
        {
            animator.SetBool("IsAdore", false);
            animator.SetBool("IsAkimbo", false);
            animator.SetBool("IsAngry", false);
            animator.SetBool("IsComplacement", false);
            animator.SetBool("IsConfident", false);
            animator.SetBool("IsConfused", false);
            animator.SetBool("IsHappy", true);
            animator.SetBool("IsSad", false);
            animator.SetBool("IsSulk", false);
            animator.SetBool("IsSurprised", false);
        }
        if (type == MartyAnimationEventType.Sad)
        {
            animator.SetBool("IsAdore", false);
            animator.SetBool("IsAkimbo", false);
            animator.SetBool("IsAngry", false);
            animator.SetBool("IsComplacement", false);
            animator.SetBool("IsConfident", false);
            animator.SetBool("IsConfused", false);
            animator.SetBool("IsHappy", false);
            animator.SetBool("IsSad", true);
            animator.SetBool("IsSulk", false);
            animator.SetBool("IsSurprised", false);
        }
        if (type == MartyAnimationEventType.Sulk)
        {
            animator.SetBool("IsAdore", false);
            animator.SetBool("IsAkimbo", false);
            animator.SetBool("IsAngry", false);
            animator.SetBool("IsComplacement", false);
            animator.SetBool("IsConfident", false);
            animator.SetBool("IsConfused", false);
            animator.SetBool("IsHappy", false);
            animator.SetBool("IsSad", false);
            animator.SetBool("IsSulk", true);
            animator.SetBool("IsSurprised", false);
        }
        if (type == MartyAnimationEventType.Surprised)
        {
            animator.SetBool("IsAdore", false);
            animator.SetBool("IsAkimbo", false);
            animator.SetBool("IsAngry", false);
            animator.SetBool("IsComplacement", false);
            animator.SetBool("IsConfident", false);
            animator.SetBool("IsConfused", false);
            animator.SetBool("IsHappy", false);
            animator.SetBool("IsSad", false);
            animator.SetBool("IsSulk", false);
            animator.SetBool("IsSurprised", true);
        }

        if (type == MartyAnimationEventType.EmptySunGlass)
        {
            animator.SetBool("IsSunGlass", false);
        }
        if (type == MartyAnimationEventType.SunGlass)
        {
            animator.SetBool("IsSunGlass", true);
        }
    }


}
