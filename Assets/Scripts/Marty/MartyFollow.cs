using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MartyFollow : MonoBehaviour
{
    public Transform dialogPos;
    public float followRange;
    public UnityEvent initialEvents;
    public bool isFollow = true;

    public float movementLerpValue;

    void Start()
    {
        transform.position = dialogPos.position;
        initialEvents.Invoke();
    }

    void Update()
    {
        if (!GameManager.instance.isPaused)
        {
            if (GameManager.instance.player.GetComponent<PlayerGridMovement>().isInDialog || !isFollow)
            {
                transform.position = Vector3.Lerp(transform.position, dialogPos.position, movementLerpValue * Time.deltaTime);
            }
            else
            {
                if(Vector2.Distance(GameManager.instance.player.transform.position, transform.position) > followRange)
                {
                    transform.position = Vector3.Lerp(transform.position, GameManager.instance.player.transform.position, movementLerpValue * Time.deltaTime);
                }
            }
        }
    }

    public void SetDialogPos(Transform target)
    {
        dialogPos = target;
    }

    public void SetFollow(bool flag)
    {
        isFollow = flag;
    }
}
