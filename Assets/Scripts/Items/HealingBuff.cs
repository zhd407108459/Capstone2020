using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBuff : BasicBuff
{
    public int healingValue;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public override void OnBeat(int beatIndex)
    {
        if (existingTimer > 0)
        {
            existingTimer--;
            if (existingTimer == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            GameManager.instance.player.GetComponent<PlayerHealth>().Recover(healingValue);
            Destroy(this.gameObject);
        }
    }
}
