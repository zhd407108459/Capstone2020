using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidAttack : RhythmObject
{
    public float movementLerpValue;

    public GameObject sprite;
    public int damage;

    public int attackDelay;
    public int stayDelay;


    [HideInInspector] public int xPos;
    [HideInInspector] public int yPos;

    private int midX;
    private int midY;

    [HideInInspector] public int endX;
    [HideInInspector] public int endY;

    [HideInInspector] public Vector3 targetPos;
    [HideInInspector] public int delayTimer;
    [HideInInspector] public int state;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.instance.isPaused)
        {
            return;
        }
        if (Vector2.Distance(transform.position, targetPos) > 0.0001f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, movementLerpValue * Time.deltaTime);
        }
    }

    public override void OnBeat(int beatIndex)
    {
        delayTimer++;
        if(delayTimer >= attackDelay && state == 0)
        {
            targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(midX * GridManager.instance.gridSize.x, midY * GridManager.instance.gridSize.y);
            state = 1;
            delayTimer = 0;
        }
        if(delayTimer >= stayDelay && state == 1)
        {
            targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(endX * GridManager.instance.gridSize.x, endY * GridManager.instance.gridSize.y);
            state = 2;
            delayTimer = 0;
        }
        if(delayTimer >= 4 && state == 2)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetUp(int x, int y, int midX, int midY, int endX, int endY, int damage, int attackDelay, int stayDelay, float rotationZ)//0 = left to right, 180 = right to left, 90 = bottom to top, 270 = top to bottom
    {
        xPos = x;
        yPos = y;
        targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
        this.damage = damage;
        this.attackDelay = attackDelay;
        this.stayDelay = stayDelay;
        this.midX = midX;
        this.midY = midY;
        this.endX = endX;
        this.endY = endY;
        delayTimer = 0;
        state = 0;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag.Equals("Player") && (state == 1 || state == 2))
    //    {
    //        collision.GetComponent<PlayerHealth>().TakeDamage(damage);
    //    }
    //    if (collision.tag.Equals("PlayerShield"))
    //    {
    //        targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(endX * GridManager.instance.gridSize.x, endY * GridManager.instance.gridSize.y);
    //        state = 2;
    //        delayTimer = 0;
    //    }
    //}

}
