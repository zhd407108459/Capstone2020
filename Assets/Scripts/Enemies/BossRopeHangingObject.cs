using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BossRopeHangingObject : RhythmObject
{
    public int stayDelay;
    public AnimationCurve heightAnimationCurve;
    public AnimationCurve heightAnimationBackCurve;
    public float movementTime;

    private int targetX;
    private int targetY;

    private int movementStage;
    private float movementTimer;
    private int stayTimer;
    private Vector3 targetPos;
    private Vector3 originPos;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.instance.isPaused || GameManager.instance.isGameEnd)
        {
            return;
        }
        if (movementStage == 0)
        {
            movementTimer += Time.deltaTime;
            if (movementTimer >= movementTime)
            {
                movementTimer = movementTime;
                movementStage = 1;
                stayTimer = 0;
            }
            transform.position = new Vector3(transform.position.x, heightAnimationCurve.Evaluate(movementTimer / movementTime) * originPos.y + heightAnimationCurve.Evaluate(1.0f - (movementTimer / movementTime)) * targetPos.y, transform.position.z);

        }
        if (movementStage == 2)
        {
            movementTimer += Time.deltaTime;
            if (movementTimer >= movementTime)
            {
                movementTimer = movementTime;
                Destroy(this.gameObject);
            }
            transform.position = new Vector3(transform.position.x, heightAnimationBackCurve.Evaluate(movementTimer / movementTime) * originPos.y + heightAnimationBackCurve.Evaluate(1.0f - (movementTimer / movementTime)) * targetPos.y, transform.position.z);
        }
    }

    public override void OnBeat(int beatIndex)
    {
        base.OnBeat(beatIndex);
        if (movementStage == 1)
        {
            if (stayTimer > stayDelay)
            {
                movementStage = 2;
                movementTimer = 0;
            }
            stayTimer++;
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
