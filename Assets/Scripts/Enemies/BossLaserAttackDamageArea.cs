using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserAttackDamageArea : MonoBehaviour
{
    public BossLaserAttack parent;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && (parent.state == 1))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(parent.damage);
        }
    }
}
