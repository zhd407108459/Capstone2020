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
            bool isFindPlayer = false;
            RaycastHit2D[] rh2d = Physics2D.LinecastAll(transform.position, lastPos);
            for (int i = 0; i < rh2d.Length; i++)
            {
                //Debug.LogError(rh2d[i].transform.gameObject);
                if (rh2d[i].collider.tag.Equals("Player") && !GameManager.instance.player.GetComponent<PlayerDash>().isDashing)
                {
                    Debug.LogError(transform.position);
                    Debug.LogError(lastPos);
                    parent.CatchPlayer();
                    isFindPlayer = true;
                }
            }
            if (!isFindPlayer)
            {
                for (int i = 0; i < rh2d.Length; i++)
                {
                    if (rh2d[i].collider.tag.Equals("PlayerBomb"))
                    {
                        parent.CatchBomb(rh2d[i].collider.gameObject);
                    }
                }
            }
            lastPos = transform.position;
        }
    }

    public void ResetLastPos()
    {
        lastPos = transform.position;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag.Equals("Player") && parent.GetStage() == 3 && !GameManager.instance.player.GetComponent<PlayerDash>().isDashing)
    //    {
    //        parent.CatchPlayer();
    //    }
    //    if (collision.tag.Equals("PlayerBomb") && parent.GetStage() == 3)
    //    {
    //        parent.CatchBomb(collision.gameObject);
    //    }
    //}


    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag.Equals("Player") && parent.GetStage() == 3 && !GameManager.instance.player.GetComponent<PlayerDash>().isDashing)
    //    {
    //        parent.CatchPlayer();
    //    }
    //    if (collision.tag.Equals("PlayerBomb") && parent.GetStage() == 3)
    //    {
    //        parent.CatchBomb(collision.gameObject);
    //    }
    //}
}
