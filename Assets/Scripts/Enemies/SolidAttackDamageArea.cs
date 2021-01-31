using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidAttackDamageArea : MonoBehaviour
{
    public SolidAttack parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && (parent.state == 1 || parent.state == 2))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(parent.damage);
        }
        if (collision.tag.Equals("PlayerShield"))
        {
            parent.targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(parent.endX * GridManager.instance.gridSize.x, parent.endY * GridManager.instance.gridSize.y);
            parent.state = 2;
            parent.delayTimer = 0;
        }
    }
}
