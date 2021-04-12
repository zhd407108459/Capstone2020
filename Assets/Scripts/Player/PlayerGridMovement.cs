using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class PlayerGridMovement : MonoBehaviour
{
    public GameObject sprite;
    public Animator animator;
    public float movementLerpValue;
    public float actionTolerance;

    public int xPos;
    public int yPos;

    public string moveFXEventPath = "event:/FX/Player/FX-Footsteps";

    [HideInInspector] public bool isPlayerFacingRight;
    [HideInInspector] public bool isInDialog;

    private Vector3 targetPos;
    private PlayerAction action;

    private void Awake()
    {
        action = GetComponent<PlayerAction>();
    }

    void Start()
    {
        //transform.position = GridManager.instance.initialPos + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
        //targetPos = GridManager.instance.initialPos + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
        isPlayerFacingRight = true;
        isInDialog = false;
    }

    void Update()
    {
        if (BeatsManager.instance.GetTimeToNearestBeat() <= actionTolerance && !action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] && GridManager.instance.isInPhase && !action.isDizzy && !GameManager.instance.isPaused && !isInDialog && !GameManager.instance.isCutScene)
        {
            Move();
        }
        if (Vector2.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, movementLerpValue * Time.deltaTime);
        }
        //else if (GetComponent<PlayerDash>().isDashing)
        //{
        //    GetComponent<PlayerDash>().EndDash();
        //}
    }

    public void Move()
    {
        if ((Input.GetKeyDown(KeyCode.W) && !action.IsChaos()) || (Input.GetKeyDown(KeyCode.S) && action.IsChaos())) 
        {
            //if (GetComponent<PlayerDash>().availability[BeatsManager.instance.GetIndexToNearestBeat()])
            //{
            //    if (GridManager.instance.IsPlatformExist(xPos, yPos + 2))
            //    {
            //        SetPos(xPos, yPos + 2);
            //    }
            //    else if (GridManager.instance.IsPlatformExist(xPos, yPos + 1))
            //    {
            //        SetPos(xPos, yPos + 1);
            //    }
            //    GetComponent<PlayerDash>().StartDash();
            //    animator.SetTrigger("Jump");
            //}
            //else
            //{
            if (GridManager.instance.IsPlatformExist(xPos, yPos + 1))
            {
                SetPos(xPos, yPos + 1);
                animator.SetTrigger("Jump");
            }
            //}
        }
        else if ((Input.GetKeyDown(KeyCode.S) && !action.IsChaos()) || (Input.GetKeyDown(KeyCode.W) && action.IsChaos()))
        {
            //if (GetComponent<PlayerDash>().availability[BeatsManager.instance.GetIndexToNearestBeat()])
            //{
            //    SetPos(xPos, yPos - 2);
            //    GetComponent<PlayerDash>().StartDash();
            //    animator.SetTrigger("Jump");
            //}
            //else
            //{
            SetPos(xPos, yPos - 1);
            animator.SetTrigger("Jump");
            //}
        }
        else if ((Input.GetKeyDown(KeyCode.D) && !action.IsChaos()) || (Input.GetKeyDown(KeyCode.A) && action.IsChaos()))
        {
            sprite.transform.localScale = new Vector3(Mathf.Abs(sprite.transform.localScale.x), sprite.transform.localScale.y, sprite.transform.localScale.z);
            isPlayerFacingRight = true;
            //if (GetComponent<PlayerDash>().availability[BeatsManager.instance.GetIndexToNearestBeat()])
            //{
            //    SetPos(xPos + 2, yPos);
            //    GetComponent<PlayerDash>().StartDash();
            //    animator.SetTrigger("Jump");
            //}
            //else
            //{
            SetPos(xPos + 1, yPos);
            animator.SetTrigger("Jump");
            //}
        }
        else if ((Input.GetKeyDown(KeyCode.A) && !action.IsChaos()) || (Input.GetKeyDown(KeyCode.D) && action.IsChaos()))
        {
            sprite.transform.localScale = new Vector3(-Mathf.Abs(sprite.transform.localScale.x), sprite.transform.localScale.y, sprite.transform.localScale.z);
            isPlayerFacingRight = false;
            //if (GetComponent<PlayerDash>().availability[BeatsManager.instance.GetIndexToNearestBeat()])
            //{
            //    SetPos(xPos - 2, yPos);
            //    GetComponent<PlayerDash>().StartDash();
            //    animator.SetTrigger("Jump");
            //}
            //else
            //{
            SetPos(xPos - 1, yPos);
            animator.SetTrigger("Jump");
            //}
        }
        else if ((Input.GetKeyDown(KeyCode.Q) && !action.IsChaos()) || (Input.GetKeyDown(KeyCode.E) && action.IsChaos()))
        {
            if(sprite.transform.localScale.x > 0)
            {
                isPlayerFacingRight = false;
                sprite.transform.localScale = new Vector3(-Mathf.Abs(sprite.transform.localScale.x), sprite.transform.localScale.y, sprite.transform.localScale.z);
                action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;//Moved
            }
        }
        else if ((Input.GetKeyDown(KeyCode.E) && !action.IsChaos()) || (Input.GetKeyDown(KeyCode.Q) && action.IsChaos()))
        {
            if (sprite.transform.localScale.x < 0)
            {
                isPlayerFacingRight = true;
                sprite.transform.localScale = new Vector3(Mathf.Abs(sprite.transform.localScale.x), sprite.transform.localScale.y, sprite.transform.localScale.z);
                action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;//Moved
            }
        }
        else if (Input.GetKeyDown(GetComponent<PlayerDash>().triggerKey) && GetComponent<PlayerDash>().abilityIcon != null && !action.IsOffTune())
        {
            if (GetComponent<PlayerDash>().abilityIcon.isCoolDown)
            {
                if(isPlayerFacingRight)
                {
                    SetPos(xPos + 2, yPos);
                    GetComponent<PlayerDash>().StartDash();
                    animator.SetTrigger("Jump");
                }
                else
                {
                    SetPos(xPos - 2, yPos);
                    GetComponent<PlayerDash>().StartDash();
                    animator.SetTrigger("Jump");
                }
                //GridManager.instance.AddCombo();
                GetComponent<PlayerAction>().comboBreakTimer = 0;
                action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;//Moved
            }
        }
        if (action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] && GridManager.instance.IsInBattlePhase())
        {
            GridManager.instance.AddCombo();
            GetComponent<PlayerAction>().comboBreakTimer = 0;
        }
    }

    public void ResetPos()
    {
        xPos = 0;
        yPos = 0;
        targetPos = GridManager.instance.GetPhaseInitialPosition();
        transform.position = targetPos;
    }

    public void SetPos(int x, int y)
    {
        if (x < 0)
        {
            xPos = 0;
        }
        else if (x >= GridManager.instance.GetPhaseLength())
        {
            xPos = GridManager.instance.GetPhaseLength() - 1;
            //Temp
            if(GridManager.instance.phaseIndex < GridManager.instance.phases.Count - 1)
            {
                if (GridManager.instance.IsInBattlePhase() && !GridManager.instance.isBossFight)
                {
                    if (GridManager.instance.IsEnemyClear())
                    {
                        if (SettingManager.instance != null)
                        {
                            if (GridManager.instance.levelIndex == SettingManager.instance.levelProcess && GridManager.instance.phaseIndex > (SettingManager.instance.phaseProcess - 1) * 2)
                            {
                                SettingManager.instance.phaseProcess += 1;
                                SettingManager.instance.SaveToPath();
                            }
                        }
                        GridManager.instance.EndCurrentPhase();
                        GridManager.instance.StartNextPhase();
                    }
                }
                else
                {
                    GridManager.instance.EndCurrentPhase();
                    GridManager.instance.StartNextPhase();
                }

            }
            else
            {
                if (!GridManager.instance.isBossFight)
                {
                    if (GridManager.instance.IsEnemyClear())
                    {
                        if (SettingManager.instance != null)
                        {
                            if (GridManager.instance.levelIndex == SettingManager.instance.levelProcess && GridManager.instance.phaseIndex > (SettingManager.instance.phaseProcess - 1) * 2)
                            {
                                SettingManager.instance.phaseProcess += 1;
                                SettingManager.instance.SaveToPath();
                            }
                        }
                        GameManager.instance.LoadNextScene();
                    }
                }
            }
        }
        else
        {
            xPos = x;
            action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;//Moved

            EventInstance moveFX;
            moveFX = RuntimeManager.CreateInstance(moveFXEventPath);
            if (SettingManager.instance != null)
            {
                moveFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
                //moveFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
            }
            moveFX.start();
        }
        if (y < 0)
        {
            yPos = 0;
        }
        else if (y >= GridManager.instance.battleColumnGridCount)
        {
            yPos = GridManager.instance.battleColumnGridCount - 1;
        }
        else
        {
            int tempY = GridManager.instance.GetFirstLowerPlatformYPosition(xPos, y);
            if(yPos != tempY)
            {
                action.isActionUsed[BeatsManager.instance.GetIndexToNearestBeat()] = true;//Moved

                EventInstance moveFX;
                moveFX = RuntimeManager.CreateInstance(moveFXEventPath);
                if (SettingManager.instance != null)
                {
                    moveFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
                    //moveFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
                }
                moveFX.start();
            }
            yPos = tempY;
        }
        GridManager.instance.DetectDialogTrigger(xPos, yPos);
        targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
    }

    public void CheckYPosition()
    {
        int tempY = GridManager.instance.GetFirstLowerPlatformYPosition(xPos, yPos);
        if (yPos != tempY)
        {
            EventInstance moveFX;
            moveFX = RuntimeManager.CreateInstance(moveFXEventPath);
            if (SettingManager.instance != null)
            {
                moveFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
                //moveFX.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
            }
            moveFX.start();
            yPos = tempY;
            targetPos = GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
        }
    }

    public bool IsPlayerInActualPosition()
    {
        if (Vector2.Distance(targetPos, transform.position) < 0.05f) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
