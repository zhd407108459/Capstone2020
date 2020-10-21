using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyingTrap : BasicTrap
{
    public int effectTime;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            GameManager.instance.player.GetComponent<PlayerAction>().StartDizzy(effectTime);
            this.gameObject.SetActive(false);
        }
    }
}
