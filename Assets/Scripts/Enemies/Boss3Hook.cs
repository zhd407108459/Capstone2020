using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Hook : MonoBehaviour
{
    public Boss3HookTracker parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && parent.GetStage() == 3)
        {
            parent.CatchPlayer();
        }
    }
}
