using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : RhythmObject
{
    public static GridManager instance;

    public Vector2 gridSize;
    public Vector2 initialPos;

    public float cameraDistanceToBoundary;
    public GameObject cameraObject;
    public float cameraFollowLerpValue;
    public GameObject fixedBackground;

    public List<PhaseInfo> phases = new List<PhaseInfo>();

    public int phaseIndex = 0;

    public int battleRowGridCount;
    public int battleColumnGridCount;

    public int preActivateTime;
    public Text timerText;

    public SetAbilities setAbilities;

    [HideInInspector] public Vector3 targetCameraPos;
    [HideInInspector] public bool isCameraFollowing;
    [HideInInspector] public bool isInPhase;

    private bool isCounting;
    private int timer;
    private int generateBuffsInterval;
    private int generateDebuffsInterval;
    private int generateBuffsTimer;
    private int generateDebuffsTimer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        targetCameraPos = cameraObject.transform.position;
        Initialize();
    }

    void Update()
    {
        if (isCameraFollowing && !GameManager.instance.isPaused)
        {
            UpdateTargetCameraPosition();
            cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position, targetCameraPos, cameraFollowLerpValue * Time.deltaTime);
            fixedBackground.transform.position = new Vector3(cameraObject.transform.position.x, cameraObject.transform.position.y, fixedBackground.transform.position.z);
        }
    }

    private void Initialize()
    {
        phaseIndex = 0;
        isInPhase = true;
        if (!IsInBattlePhase())
        {
            isCameraFollowing = true;
        }
        else
        {
            isCameraFollowing = false;
        }
        for (int i = 0; i < phases.Count; i++)
        {
            phases[i].Initialize();
        }
    }

    public void EndCurrentPhase()
    {
        isInPhase = false;
    }

    public void StartNextPhase()
    {
        if(phaseIndex < phases.Count - 1)
        {
            phaseIndex++;
            if (!IsInBattlePhase())
            {
                isCameraFollowing = true;
                setAbilities.ClearAbilities();
                for(int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
                {
                    BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().HideIcons();
                }
                isInPhase = true;
            }
            else
            {
                for(int i = 0; i < phases[phaseIndex].enemies.Count; i++)
                {
                    phases[phaseIndex].enemies[i].transform.position = GetPhaseInitialPosition() + new Vector2(phases[phaseIndex].enemies[i].xPos * gridSize.x, phases[phaseIndex].enemies[i].yPos * gridSize.y);
                }
                for(int i = 0; i < phases[phaseIndex].traps.Count; i++)
                {
                    phases[phaseIndex].traps[i].transform.position = GetPhaseInitialPosition() + new Vector2(phases[phaseIndex].traps[i].xPos * gridSize.x, phases[phaseIndex].traps[i].yPos * gridSize.y);
                }
                setAbilities.Show();
            }
            GameManager.instance.player.GetComponent<PlayerGridMovement>().SetPos(0, GameManager.instance.player.GetComponent<PlayerGridMovement>().yPos);
        }
    }

    public void RestartCurrentPhase()
    {
        GameManager.instance.player.GetComponent<PlayerGridMovement>().SetPos(0, 0);
        for (int i = 0; i < phases[phaseIndex].enemies.Count; i++)
        {
            phases[phaseIndex].enemies[i].gameObject.SetActive(true);
            phases[phaseIndex].enemies[i].Activate();
            phases[phaseIndex].enemies[i].transform.position = GetPhaseInitialPosition() + new Vector2(phases[phaseIndex].enemies[i].xPos * gridSize.x, phases[phaseIndex].enemies[i].yPos * gridSize.y);
        }
    }

    public void PreActivateCurrentPhase()
    {
        timer = 0;
        isCounting = true;
        timerText.gameObject.SetActive(true);
        timerText.text = (preActivateTime - timer).ToString();
    }

    public void ActivateCurrentPhase()
    {
        isInPhase = true;
        for (int i = 0; i < phases[phaseIndex].enemies.Count; i++)
        {
            phases[phaseIndex].enemies[i].Activate();
        }
        isCounting = false;
        ResetGeneratingBuffsAndDebuffs();
        Invoke("HideTimerText", BeatsManager.instance.beatsTime);
    }

    void ResetGeneratingBuffsAndDebuffs()
    {
        generateBuffsInterval = Random.Range(phases[phaseIndex].minGenerateBuffsInterval, phases[phaseIndex].maxGenerateBuffsInterval + 1);
        generateDebuffsInterval = Random.Range(phases[phaseIndex].minGenerateDebuffsInterval, phases[phaseIndex].maxGenerateDebuffsInterval + 1);
        generateBuffsTimer = 0;
        generateDebuffsTimer = 0;
    }

    void HideTimerText()
    {
        timerText.gameObject.SetActive(false);
    }

    public override void OnBeat(int beatIndex)
    {
        if (isCounting)
        {
            timer++;
            timerText.text = (preActivateTime - timer).ToString();
            if (timer >= preActivateTime)
            {
                ActivateCurrentPhase();
            }
        }
        if (isInPhase && !isCounting)
        {
            if(generateBuffsTimer >= generateBuffsInterval && phases[phaseIndex].generateBuffs.Count > 0)
            {
                GenerateBuff();
                generateBuffsInterval = Random.Range(phases[phaseIndex].minGenerateBuffsInterval, phases[phaseIndex].maxGenerateBuffsInterval + 1);
                generateBuffsTimer = 0;
            }
            if(generateDebuffsTimer >= generateDebuffsInterval && phases[phaseIndex].generateDebuffs.Count > 0)
            {
                GenerateDebuff();
                generateDebuffsInterval = Random.Range(phases[phaseIndex].minGenerateDebuffsInterval, phases[phaseIndex].maxGenerateDebuffsInterval + 1);
                generateDebuffsTimer = 0;
            }
            generateDebuffsTimer++;
            generateBuffsTimer++;
        }
    }

    void GenerateBuff()
    {
        if(phases[phaseIndex].generateBuffs.Count == 0)
        {
            return;
        }
    }

    void GenerateDebuff()
    {
        if (phases[phaseIndex].generateDebuffs.Count == 0)
        {
            return;
        }
    }

    public bool IsInBattlePhase()
    {
        return phases[phaseIndex].isBattlePhase;
    }

    public void UpdateTargetCameraPosition()
    {
        if (!IsInBattlePhase())
        {
            if (GameManager.instance.player.transform.position.x < GetPhaseInitialPosition().x + cameraDistanceToBoundary)
            {
                targetCameraPos = new Vector3(GetPhaseInitialPosition().x + cameraDistanceToBoundary, cameraObject.transform.position.y, cameraObject.transform.position.z);
            }
            else if (GameManager.instance.player.transform.position.x > GetPhaseEndPosition().x - cameraDistanceToBoundary)
            {
                targetCameraPos = new Vector3(GetPhaseEndPosition().x - cameraDistanceToBoundary, cameraObject.transform.position.y, cameraObject.transform.position.z);
            }
            else
            {
                targetCameraPos = new Vector3(GameManager.instance.player.transform.position.x, cameraObject.transform.position.y, cameraObject.transform.position.z);
            }
        }
        else
        {
            targetCameraPos = new Vector3(GetPhaseInitialPosition().x + cameraDistanceToBoundary, cameraObject.transform.position.y, cameraObject.transform.position.z);
        }
    }

    public int GetPhaseLength()
    {
        return phases[phaseIndex].phaseLength;
    }

    public Vector2 GetPhaseInitialPosition()
    {
        Vector2 pos = initialPos;
        for(int i = 0; i < phaseIndex; i++)
        {
            pos += new Vector2((phases[i].phaseLength - 1) * gridSize.x, 0);
        }
        return pos;
    }
    public Vector2 GetPhaseEndPosition()
    {
        Vector2 pos = initialPos;
        for (int i = 0; i <= phaseIndex; i++)
        {
            pos += new Vector2((phases[i].phaseLength - 1) * gridSize.x, 0);
        }
        return pos;
    }
    public int GetFirstLowerPlatformYPosition(int x, int y)
    {
        int nextY = 0;
        for(int i = 0; i < phases[phaseIndex].basicPlatforms.Count; i++)
        {
            if (phases[phaseIndex].basicPlatforms[i] != null)
            {
                if (phases[phaseIndex].basicPlatforms[i].xPos == x && phases[phaseIndex].basicPlatforms[i].yPos > nextY && phases[phaseIndex].basicPlatforms[i].yPos <= y)
                {
                    nextY = phases[phaseIndex].basicPlatforms[i].yPos;
                }
            }
        }
        return nextY;
    }

    public bool IsPlatformExist(int x, int y)
    {
        for (int i = 0; i < phases[phaseIndex].basicPlatforms.Count; i++)
        {
            if(phases[phaseIndex].basicPlatforms[i] != null)
            {
                if (phases[phaseIndex].basicPlatforms[i].xPos == x && phases[phaseIndex].basicPlatforms[i].yPos == y)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool IsEnemyExist(int x, int y)
    {
        for (int i = 0; i < phases[phaseIndex].enemies.Count; i++)
        {
            if (phases[phaseIndex].enemies[i] != null)
            {
                if (phases[phaseIndex].enemies[i].xPos == x && phases[phaseIndex].enemies[i].yPos == y)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool IsEnemyClear()
    {
        if (IsInBattlePhase())
        {
            for(int i = 0; i < phases[phaseIndex].enemies.Count; i++)
            {
                if (phases[phaseIndex].enemies[i].gameObject.activeSelf)
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return true;
        }
    }
}
