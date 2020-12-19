using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartyFollow : MonoBehaviour
{
    public Transform dialogPos;
    public float followRange;

    public float movementLerpValue;

    void Start()
    {
        transform.position = dialogPos.position;
    }

    void Update()
    {
        if (!GameManager.instance.isPaused)
        {
            if (GameManager.instance.player.GetComponent<PlayerGridMovement>().isInDialog)
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
}
