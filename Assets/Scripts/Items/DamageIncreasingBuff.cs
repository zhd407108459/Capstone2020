using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIncreasingBuff : BasicBuff
{
    public float damageIncreasementRatio;
    public int effectTime;

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
            GameManager.instance.player.GetComponent<PlayerAction>().StartIncreasingDamage(effectTime, damageIncreasementRatio);
            Destroy(this.gameObject);
        }
    }
}
