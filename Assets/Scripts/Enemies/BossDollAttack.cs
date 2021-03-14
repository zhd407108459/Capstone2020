using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BossDollAttack : RhythmObject
{
    public int attackDelay;
    public int damage;
    public BoxCollider2D damageArea;
    public AnimationCurve heightAnimationCurve;
    public AnimationCurve heightAnimationBackCurve;
    public float movementTime;

    private int targetX;
    private int targetY;

    private int movementStage;
    private float movementTimer;
    private int attackTimer;
    private Vector3 targetPos;
    private Vector3 originPos;

    void Start()
    {
        
    }

    void Update()
    {
        if(GameManager.instance.isPaused || GameManager.instance.isGameEnd)
        {
            return;
        }
        if(movementStage == 0)
        {
            movementTimer += Time.deltaTime;
            if(movementTimer >= movementTime)
            {
                movementTimer = movementTime;
                movementStage = 1;
                attackTimer = 0;
            }
            transform.position = heightAnimationCurve.Evaluate(movementTimer / movementTime) * targetPos + heightAnimationCurve.Evaluate(1.0f - (movementTimer / movementTime)) * originPos;
            
        }
        if (movementStage == 2)
        {
            movementTimer += Time.deltaTime;
            if (movementTimer >= movementTime)
            {
                movementTimer = movementTime;
                Destroy(this.gameObject);
            }
            transform.position = heightAnimationBackCurve.Evaluate(movementTimer / movementTime) * originPos + heightAnimationBackCurve.Evaluate(1.0f - (movementTimer / movementTime)) * targetPos;

        }
    }

    public override void OnBeat(int beatIndex)
    {
        base.OnBeat(beatIndex);
        if(movementStage == 1)
        {
            if(attackTimer == attackDelay)
            {
                Collider2D[] cos = Physics2D.OverlapBoxAll(damageArea.transform.position, new Vector2(damageArea.size.x * damageArea.transform.localScale.x, damageArea.size.y * damageArea.transform.localScale.y), damageArea.transform.rotation.eulerAngles.z);
                for (int i = 0; i < cos.Length; i++)
                {
                    if (cos[i].tag.Equals("Player"))
                    {
                        cos[i].GetComponent<PlayerHealth>().TakeDamage(damage);
                    }
                }
            }
            if(attackTimer > attackDelay)
            {
                movementStage = 2;
                movementTimer = 0;
            }
            attackTimer++;
        }
    }

    public void SetUp(int x, int y)
    {
        targetX = x;
        targetY = y;
        transform.position = GridManager.instance.GetPhaseInitialPosition() + new Vector2(targetX * GridManager.instance.gridSize.x, 6 * GridManager.instance.gridSize.y);
        originPos = transform.position;
        targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(targetX * GridManager.instance.gridSize.x, targetY * GridManager.instance.gridSize.y);
        movementStage = 0;
        movementTimer = 0;
    }
}
