using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Hook : MonoBehaviour
{
    public Boss3HookTracker parent;

    private Vector3 lastPos;

    private void Start()
    {
        lastPos = transform.position;
    }

    private void Update()
    {
        if (GameManager.instance.isPaused || GameManager.instance.isGameEnd)
        {
            return;
        }
        if(parent.GetStage() == 3)
        {
            RaycastHit2D[] rh2d = Physics2D.LinecastAll(transform.position, lastPos);
            for (int i = 0; i < rh2d.Length; i++)
            {
                if (rh2d[i].collider.tag.Equals("Player"))
                {
                    parent.CatchPlayer();
                }
            }
            lastPos = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && parent.GetStage() == 3)
        {
            parent.CatchPlayer();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && parent.GetStage() == 3)
        {
            parent.CatchPlayer();
        }
    }
}
