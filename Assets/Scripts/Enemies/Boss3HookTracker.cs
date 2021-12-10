using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class Boss3HookTracker : RhythmObject
{
    public int attackDelay;
    public int grabbingTime;
    public int damage;


    public AnimationCurve spriteAnimationCurve;
    public AnimationCurve hookAnimationCurve;

    public GameObject sprite;
    public float spriteY;

    public GameObject hook;
    public float defaultHookLocalHeight;
    public float floorHookLocalHeight;

    public float movementTime;

    public string catchingFXPath;
    public string caughtFXPath;
    public string caughtPostFXPath;
    public string notCaughtFXPath;

    private float movementTimer;

    private int targetX;
    private int targetY;

    private float targetXPos;
    private float hookTargetYPos;
    private int movementStage;

    private int attackTimer;

    private bool isCaughtPlayer;
    private int releaseTimer;

    private bool waitflag = false;

    private GameObject bomb;
    private int postCaughtTimer = -1;

    void Start()
    {
    }

    void Update()
    {

        if (GameManager.instance.isPaused || GameManager.instance.isGameEnd)
        {
            return;
        }
        if (movementStage != 0 && !(isCaughtPlayer && movementStage == 3) && !(bomb != null && movementStage == 3))
        {
            movementTimer += Time.deltaTime;
            if (movementTimer >= movementTime)
            {
                movementTimer = 0;
            }
            sprite.transform.position = new Vector3(spriteAnimationCurve.Evaluate(movementTimer / movementTime) * targetXPos + spriteAnimationCurve.Evaluate(1 - (movementTimer / movementTime)) * sprite.transform.position.x, spriteY);
            hook.transform.localPosition = new Vector3(0, hookAnimationCurve.Evaluate(movementTimer / movementTime) * hookTargetYPos + hookAnimationCurve.Evaluate(1 - (movementTimer / movementTime)) * hook.transform.localPosition.y);
        }
        if (isCaughtPlayer)
        {
            GameManager.instance.player.transform.position = hook.transform.position;
        }
        if (bomb != null)
        {
            bomb.transform.position = hook.transform.position;
        }
    }

    public override void OnBeat(int beatIndex)
    {
        base.OnBeat(beatIndex);

        if(postCaughtTimer >= 0)
        {
            if (postCaughtTimer == 0)
            {
                EventInstance caughtPostFX;
                caughtPostFX = RuntimeManager.CreateInstance(caughtPostFXPath);
                if (SettingManager.instance != null)
                {
                    //float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                    caughtPostFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume); //* (1.0f - value));
                }
                caughtPostFX.start();
            }
            postCaughtTimer--;
        }

        waitflag = !waitflag;
        if (waitflag)
        {
            return;
        }
        movementTimer = 0;
        if(movementStage == 1)
        {
            targetXPos = GridManager.instance.GetPhaseInitialPosition().x + targetX * GridManager.instance.gridSize.x;
            hookTargetYPos = defaultHookLocalHeight;
            attackTimer++;
            if(attackTimer > attackDelay)
            {
                movementStage = 2;
            }
        }
        else if(movementStage == 2)
        {
            targetXPos = GridManager.instance.GetPhaseInitialPosition().x + targetX * GridManager.instance.gridSize.x;
            hookTargetYPos = floorHookLocalHeight + targetY * GridManager.instance.gridSize.y;
            movementStage = 3;
            if (catchingFXPath != null && catchingFXPath != "")
            {
                EventInstance catchingFX;
                catchingFX = RuntimeManager.CreateInstance(catchingFXPath);
                if (SettingManager.instance != null)
                {
                    //float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                    catchingFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume); //* (1.0f - value));
                }
                catchingFX.start();
            }
        }
        else if (movementStage == 3)
        {
            targetXPos = GridManager.instance.GetPhaseInitialPosition().x + targetX * GridManager.instance.gridSize.x;
            hookTargetYPos = defaultHookLocalHeight;
            movementStage = 4;
        }
        else if (movementStage == 4)
        {
            if (isCaughtPlayer)
            {
                if(targetX < 4.5)
                {
                    targetXPos = GridManager.instance.GetPhaseInitialPosition().x + -1.5f * GridManager.instance.gridSize.x;
                }
                else
                {
                    targetXPos = GridManager.instance.GetPhaseInitialPosition().x + 11.5f * GridManager.instance.gridSize.x;
                }
                hookTargetYPos = defaultHookLocalHeight;
                movementStage = 5;
                releaseTimer = -1;
            }
            else
            {
                targetXPos = GridManager.instance.GetPhaseInitialPosition().x + 4 * GridManager.instance.gridSize.x;
                hookTargetYPos = defaultHookLocalHeight;
                movementStage = 6;
                if (!IsCatchingBomb())
                {
                    EventInstance notCaughtFX;
                    notCaughtFX = RuntimeManager.CreateInstance(notCaughtFXPath);
                    if (SettingManager.instance != null)
                    {
                        //float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
                        notCaughtFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume); //* (1.0f - value));
                    }
                    notCaughtFX.start();
                }
            }
        }
        else if (movementStage == 5)
        {
            releaseTimer++;
            if(releaseTimer > grabbingTime)
            {
                GameManager.instance.player.transform.position = GridManager.instance.GetPhaseInitialPosition() + new Vector2(4 * GridManager.instance.gridSize.x, 6 * GridManager.instance.gridSize.y);
                GameManager.instance.player.GetComponent<PlayerGridMovement>().SetPos(4, 4);
                GameManager.instance.player.GetComponent<PlayerAction>().EndCaught();
                GameManager.instance.player.GetComponent<PlayerHealth>().TakeDamage(damage);
                isCaughtPlayer = false;
                movementStage = 6;
                targetXPos = GridManager.instance.GetPhaseInitialPosition().x + 4 * GridManager.instance.gridSize.x;
                hookTargetYPos = defaultHookLocalHeight;
            }
        }
        else if (movementStage == 6)
        {
            movementStage = 0;
            if(bomb != null)
            {
                bomb.GetComponent<PlayerBomb>().Explode();
            }
        }
    }

    public void SetUp(int x, int y)
    {
        if(movementStage != 0)
        {
            return;
        }
        targetX = x;
        targetY = y;
        targetXPos = sprite.transform.position.x;
        hookTargetYPos = hook.transform.localPosition.y;
        movementStage = 1;
        attackTimer = 0;
        isCaughtPlayer = false;
        waitflag = false;
    }

    public void Initialize()
    {
        sprite.transform.position = new Vector3(GridManager.instance.GetPhaseInitialPosition().x + 4 * GridManager.instance.gridSize.x, spriteY);
        hook.transform.localPosition = new Vector3(0, defaultHookLocalHeight);
        targetXPos = GridManager.instance.GetPhaseInitialPosition().x + 4 * GridManager.instance.gridSize.x;
        hookTargetYPos = defaultHookLocalHeight;
        movementStage = 0;
        isCaughtPlayer = false;
    }

    public int GetStage()
    {
        return movementStage;
    }

    public void CatchPlayer()
    {
        if (isCaughtPlayer)
        {
            return;
        }
        GameManager.instance.player.GetComponent<PlayerAction>().StartCaught();
        targetXPos = GridManager.instance.GetPhaseInitialPosition().x + targetX * GridManager.instance.gridSize.x;
        hookTargetYPos = defaultHookLocalHeight;
        hook.transform.position = GameManager.instance.player.transform.position;
        isCaughtPlayer = true;

        EventInstance caughtFX;
        caughtFX = RuntimeManager.CreateInstance(caughtFXPath);
        if (SettingManager.instance != null)
        {
            //float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
            caughtFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume); //* (1.0f - value));
        }
        caughtFX.start();
        postCaughtTimer = 1;
    }

    public void CatchBomb(GameObject bomb)
    {
        if (isCaughtPlayer)
        {
            return;
        }
        hook.transform.position = bomb.transform.position;
        this.bomb = bomb;
        bomb.GetComponent<PlayerBomb>().delay += 100;

        EventInstance caughtFX;
        caughtFX = RuntimeManager.CreateInstance(caughtFXPath);
        if (SettingManager.instance != null)
        {
            //float value = Mathf.Clamp(Vector2.Distance(GameManager.instance.player.transform.position, transform.position), 0, SettingManager.instance.hearingRange) / SettingManager.instance.hearingRange;
            caughtFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume); //* (1.0f - value));
        }
        caughtFX.start();
        postCaughtTimer = 1;
    }

    public bool IsCatchingBomb()
    {
        if (bomb != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
