using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    public int levelIndex;

    public bool isBossFight;
    public BeatBoss boss;

    public Vector2 gridSize;
    public Vector2 initialPos;

    public CutScene startCutScene;
    public CutScene bossEndingCutScene;

    public float cameraDistanceToBoundary;
    public GameObject cameraObject;
    public float cameraFollowLerpValue;
    public GameObject fixedBackground;
    public BackgroundMovement backgroundMovement;

    public List<PhaseInfo> phases = new List<PhaseInfo>();

    public int phaseIndex = 0;

    public int battleRowGridCount;
    public int battleColumnGridCount;

    public int preActivateTime;
    public Text timerText;
    public Slider rageTimerSlider;
    public Text rageTimerText;


    public SetAbilities setAbilities;

    public GameObject nextStageIcon;

    public GameObject recordPanel;
    public Text recordText;
    public Button closeRecordPanelButton;

    public GameObject comboTipObject;
    public Text comboTipText;

    public GameObject interactionTip;
    public GameObject narrativeTip;

    public bool boss3Developing;
    public GameObject btmPanel;

    [HideInInspector] public Vector3 targetCameraPos;
    [HideInInspector] public float targetCameraSize = 5.0f;
    [HideInInspector] public bool isCameraFollowing;
    [HideInInspector] public bool isInPhase;
    [HideInInspector] public string itemEmergenceFXEventPath = "event:/FX/Item/FX-ItemEmergence";

    private Vector3 lastCameraPos;

    private bool isCounting;
    private int timer;
    private int generateBuffsInterval;
    private int generateDebuffsInterval;
    private int generateBuffsTimer;
    private int generateDebuffsTimer;

    private float rageTimer;
    private float lastRageTimer;
    private float recordTimer;

    [HideInInspector] public bool isBoss2Phase;

    [HideInInspector] public DialogSet currentDialog;
    private DialogSet nextDialog;
    private int combo;
    //private int comboTimer;

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
        if(SettingManager.instance != null)
        {
            phaseIndex = SettingManager.instance.targetPhase;
            setAbilities.SetSkillKeys();
        }
        //cameraObject.transform.position = new Vector3(0, 0, -10);
        targetCameraPos = cameraObject.transform.position;
        targetCameraSize = Camera.main.orthographicSize;
        closeRecordPanelButton.onClick.AddListener(HideRecordPanel);
        Initialize();
    }

    private void Update()
    {
        if (!GameManager.instance.isPaused)
        {
            if(currentDialog != null)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    currentDialog.SkipOrNextDialogUnit();
                }
                if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
                {
                    currentDialog.EndCurrentDialogSet();
                }
            }
            if (interactionTip.activeSelf)
            {
                interactionTip.transform.position = GameManager.instance.player.transform.position;
            }
            if(interactionTip.activeSelf && Input.GetKeyDown(KeyCode.F))
            {
                if (currentDialog != null)
                {
                    currentDialog.HideDialogUnits();
                }
                currentDialog = nextDialog;
                currentDialog.StartDialogSet();
                interactionTip.SetActive(false);
            }
        }
    }


    void LateUpdate()
    {
        if (!GameManager.instance.isPaused && !GameManager.instance.isCutScene)
        {
            UpdateTargetCameraPosition();
            if(Camera.main.orthographicSize != targetCameraSize)
            {
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetCameraSize, cameraFollowLerpValue * Time.deltaTime);
            }
            cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position, targetCameraPos, cameraFollowLerpValue * Time.deltaTime);
            fixedBackground.transform.position = new Vector3(cameraObject.transform.position.x, cameraObject.transform.position.y, fixedBackground.transform.position.z);
            backgroundMovement.MoveBackgrounds(cameraObject.transform.position.x - lastCameraPos.x);
            lastCameraPos = cameraObject.transform.position;
            if (comboTipObject.activeSelf)
            {
                comboTipText.transform.localScale = Vector3.Lerp(comboTipText.transform.localScale, new Vector3(1, 1, 1), 15.0f * Time.deltaTime);
            }
        }
        if (GameManager.instance.isGameEnd)
        {
            cameraObject.transform.position = Vector3.Lerp(cameraObject.transform.position, targetCameraPos, cameraFollowLerpValue * Time.deltaTime);
        }
        if (!GameManager.instance.isPaused && IsInBattlePhase() && isInPhase && !isBoss2Phase)
        {
            recordTimer += Time.deltaTime;
            if(rageTimer > 0 && !nextStageIcon.activeSelf)
            {
                rageTimer -= Time.deltaTime;
                //if (rageTimer / phases[phaseIndex].rageTime < 0.75f && lastRageTimer / phases[phaseIndex].rageTime >= 0.75f)
                //{
                //    BeatsManager.instance.SetNormalBGMParameter("TimeNumReact", 1);
                //}
                //if (rageTimer / phases[phaseIndex].rageTime < 0.5f && lastRageTimer / phases[phaseIndex].rageTime >= 0.5f)
                //{
                //    BeatsManager.instance.SetNormalBGMParameter("TimeNumReact", 2);
                //}
                if (rageTimer / phases[phaseIndex].rageTime < 0.25f && lastRageTimer / phases[phaseIndex].rageTime >= 0.25f)
                {
                    BeatsManager.instance.SetNormalBGMParameter("TimeNumReact", 3);
                }
                if (rageTimer <= 0 && lastRageTimer > 0)
                {
                    rageTimer = 0;
                    //Rage
                    if (!isBossFight)
                    {
                        BeatsManager.instance.SetNormalBGMParameterImmediately("TimeNumReact", 4);

                        for (int i = 0; i < phases[phaseIndex].enemies.Count; i++)
                        {
                            phases[phaseIndex].enemies[i].isRaged = true;
                        }
                    }
                    else
                    {
                        BeatsManager.instance.PauseBGM();
                        //Start the second phase
                        isBoss2Phase = true;
                        rageTimerSlider.gameObject.SetActive(false);
                        rageTimerText.gameObject.SetActive(false);
                        BeatsManager.instance.SwitchToBoss2BGM();
                        boss.StartStage2();
                        if (!boss3Developing)
                        {
                            setAbilities.Show();
                        }
                        else
                        {
                            btmPanel.SetActive(true);
                        }
                        isInPhase = false;
                        GameManager.instance.player.GetComponent<PlayerHealth>().RecoverAll();
                        foreach (var n in FindObjectsOfType<EnemyGridBullet>())
                        {
                            Destroy(n.gameObject);
                        }
                        foreach (var n in FindObjectsOfType<PlayerGridBullet>())
                        {
                            Destroy(n.gameObject);
                        }
                    }
                }
                rageTimerText.text = ((int)rageTimer).ToString() + "s";
                rageTimerSlider.value = rageTimer / phases[phaseIndex].rageTime;
                lastRageTimer = rageTimer;
            }
            
        }
    }

    private void Initialize()
    {
        if (!isBossFight && (startCutScene == null || (startCutScene != null && phaseIndex != 0)))
        {
            BeatsManager.instance.StartBeats();
        }
        else if(isBossFight)
        {
            phases[0].rageTime = BeatsManager.instance.GetBoss1BGMLength();
            //Debug.Log(BeatsManager.instance.GetBoss1BGMLength());
        }
        for (int i = 0; i < phases.Count; i++)
        {
            phases[i].Initialize();
        }
        phases[phaseIndex].startEvent.Invoke();
        if (startCutScene != null && ((SettingManager.instance != null && SettingManager.instance.targetPhase == 0) || SettingManager.instance == null))
        {
            startCutScene.Invoke();
        }
        if (!IsInBattlePhase())
        {
            isCameraFollowing = true;
            ShowNextStageIcon();
            for (int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
            {
                BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().HideIcons();
            }
            rageTimerSlider.gameObject.SetActive(false);
            isInPhase = true;
            GameManager.instance.pausePanelRestartButton.gameObject.SetActive(false);
        }
        else
        {
            HideNextStageIcon();
            for (int i = 0; i < phases[phaseIndex].basicPlatforms.Count; i++)
            {
                if (phases[phaseIndex].basicPlatforms[i].GetComponent<BrokenPlatform>() != null)
                {
                    phases[phaseIndex].basicPlatforms[i].GetComponent<BrokenPlatform>().Recover();
                }
            }
            for (int i = 0; i < phases[phaseIndex].enemies.Count; i++)
            {
                phases[phaseIndex].enemies[i].gameObject.SetActive(true);
                phases[phaseIndex].enemies[i].transform.position = GetPhaseInitialPosition() + new Vector2(phases[phaseIndex].enemies[i].xPos * gridSize.x, phases[phaseIndex].enemies[i].yPos * gridSize.y);
            }
            for (int i = 0; i < phases[phaseIndex].traps.Count; i++)
            {
                phases[phaseIndex].traps[i].gameObject.SetActive(true);
                phases[phaseIndex].traps[i].transform.position = GetPhaseInitialPosition() + new Vector2(phases[phaseIndex].traps[i].xPos * gridSize.x, phases[phaseIndex].traps[i].yPos * gridSize.y);
            }
            setAbilities.Show();
            recordTimer = 0;
            rageTimerSlider.gameObject.SetActive(true);
            rageTimer = phases[phaseIndex].rageTime;
            rageTimerText.text = ((int)rageTimer).ToString() + "s";
            rageTimerSlider.value = 1;
            GameManager.instance.pausePanelRestartButton.gameObject.SetActive(true);
        }
        GameManager.instance.player.GetComponent<PlayerGridMovement>().ResetPos();
        UpdateTargetCameraPosition();
        cameraObject.transform.position = targetCameraPos;
        lastCameraPos = cameraObject.transform.position;
        fixedBackground.transform.position = new Vector3(cameraObject.transform.position.x, cameraObject.transform.position.y, fixedBackground.transform.position.z);

    }

    public void EndCurrentPhase()
    {
        if(currentDialog != null)
        {
            currentDialog.HideDialogUnits();
        }
        foreach (var n in FindObjectsOfType<BasicBuff>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<BasicDebuff>())
        {
            Destroy(n.gameObject);
        }
        for (int i = 0; i < phases[phaseIndex].traps.Count; i++)
        {
            phases[phaseIndex].traps[i].gameObject.SetActive(false);
        }
        foreach (var n in FindObjectsOfType<EnemyGridBullet>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<EnemyReflectionBullet>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<PlayerGridBullet>())
        {
            Destroy(n.gameObject);
        }
        if (IsInBattlePhase())
        {
            //ShowRecordPanel(recordTimer);
        }
        GameManager.instance.player.GetComponent<PlayerHealth>().RecoverAll();
        GameManager.instance.player.GetComponent<PlayerAction>().ClearAllBuffs();
        isInPhase = false;
        EndCombo();
        BeatsManager.instance.SetNormalBGMParameter("Debuff", 0);
        setAbilities.RecoverCoolDown();
    }

    public void StartNextPhase()
    {
        if(phaseIndex < phases.Count - 1)
        {
            phaseIndex++;
            phases[phaseIndex].startEvent.Invoke();
            setAbilities.RecoverCoolDown();
            if (!IsInBattlePhase())
            {
                BeatsManager.instance.SetNormalBGMParameter("GamePhase", 2);
                BeatsManager.instance.SetNormalBGMParameter("TimeNumReact", 5);
                isCameraFollowing = true;
                setAbilities.ClearAbilities();
                ShowNextStageIcon();
                for(int i = 0; i < BeatsManager.instance.beatsTips.Count; i++)
                {
                    BeatsManager.instance.beatsTips[i].GetComponent<BeatTip>().HideIcons();
                }
                rageTimerSlider.gameObject.SetActive(false);
                isInPhase = true;
                GameManager.instance.pausePanelRestartButton.gameObject.SetActive(false);
            }
            else
            {
                HideNextStageIcon();
                for (int i = 0; i < phases[phaseIndex].basicPlatforms.Count; i++)
                {
                    if (phases[phaseIndex].basicPlatforms[i].GetComponent<BrokenPlatform>() != null)
                    {
                        phases[phaseIndex].basicPlatforms[i].GetComponent<BrokenPlatform>().Recover();
                    }
                }
                for (int i = 0; i < phases[phaseIndex].enemies.Count; i++)
                {
                    phases[phaseIndex].enemies[i].gameObject.SetActive(true);
                    phases[phaseIndex].enemies[i].transform.position = GetPhaseInitialPosition() + new Vector2(phases[phaseIndex].enemies[i].xPos * gridSize.x, phases[phaseIndex].enemies[i].yPos * gridSize.y);
                }
                for(int i = 0; i < phases[phaseIndex].traps.Count; i++)
                {
                    phases[phaseIndex].traps[i].gameObject.SetActive(true);
                    phases[phaseIndex].traps[i].transform.position = GetPhaseInitialPosition() + new Vector2(phases[phaseIndex].traps[i].xPos * gridSize.x, phases[phaseIndex].traps[i].yPos * gridSize.y);
                }
                setAbilities.Show();
                recordTimer = 0;
                rageTimerSlider.gameObject.SetActive(true);
                rageTimer = phases[phaseIndex].rageTime;
                rageTimerText.text = ((int)rageTimer).ToString() + "s";
                rageTimerSlider.value = 1;
                GameManager.instance.pausePanelRestartButton.gameObject.SetActive(true);
            }
            GameManager.instance.player.GetComponent<PlayerGridMovement>().SetPos(0, GameManager.instance.player.GetComponent<PlayerGridMovement>().yPos);
        }
    }

    public void RestartCurrentPhase()
    {
        GameManager.instance.player.GetComponent<PlayerGridMovement>().ResetPos();
        GameManager.instance.player.GetComponent<PlayerHealth>().RecoverAll();
        GameManager.instance.player.GetComponent<PlayerAction>().ClearAllBuffs();
        HideNextStageIcon();
        for(int i = 0; i < phases[phaseIndex].basicPlatforms.Count; i++)
        {
            if (phases[phaseIndex].basicPlatforms[i].GetComponent<BrokenPlatform>() != null)
            {
                phases[phaseIndex].basicPlatforms[i].GetComponent<BrokenPlatform>().Recover();
            }
        }
        for (int i = 0; i < phases[phaseIndex].enemies.Count; i++)
        {
            phases[phaseIndex].enemies[i].gameObject.SetActive(true);
            phases[phaseIndex].enemies[i].OnRestart();
            phases[phaseIndex].enemies[i].isActivated = false;
            phases[phaseIndex].enemies[i].health = phases[phaseIndex].enemies[i].maxHealth;
            phases[phaseIndex].enemies[i].transform.position = GetPhaseInitialPosition() + new Vector2(phases[phaseIndex].enemies[i].xPos * gridSize.x, phases[phaseIndex].enemies[i].yPos * gridSize.y);
        }
        for (int i = 0; i < phases[phaseIndex].traps.Count; i++)
        {
            phases[phaseIndex].traps[i].gameObject.SetActive(true);
            phases[phaseIndex].traps[i].transform.position = GetPhaseInitialPosition() + new Vector2(phases[phaseIndex].traps[i].xPos * gridSize.x, phases[phaseIndex].traps[i].yPos * gridSize.y);
        }
        foreach(var n in FindObjectsOfType<BasicBuff>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<BasicDebuff>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<EnemyGridBullet>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<EnemyReflectionBullet>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<PlayerGridBullet>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<SolidAttack>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<BossLaserAttack>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<EnemyBomb>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<PlayerBomb>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<BossDollAttack>())
        {
            Destroy(n.gameObject);
        }
        foreach (var n in FindObjectsOfType<BossRopeHangingObject>())
        {
            Destroy(n.gameObject);
        }
        if (isBossFight)
        {
            boss.Reset();
            BeatsManager.instance.bgmEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        rageTimer = phases[phaseIndex].rageTime;
        rageTimerText.text = ((int)rageTimer).ToString() + "s";
        rageTimerSlider.value = 1;
        ResetGeneratingBuffsAndDebuffs();
        isInPhase = false;
        setAbilities.Show();
        BeatsManager.instance.SetNormalBGMParameter("TimeNumReact", 5);
    }

    public void PreActivateCurrentPhase()
    {
        timer = 0;
        isCounting = true;
        timerText.gameObject.SetActive(true);
        timerText.text = (preActivateTime - timer).ToString();
        BeatsManager.instance.SetNormalBGMParameter("GamePhase", 0);
        BeatsManager.instance.SetNormalBGMParameter("TimeNumReact", 0);
        if (isBossFight)
        {
            BeatsManager.instance.StartBeats();
        }
    }

    public void ActivateCurrentPhase()
    {
        isInPhase = true;
        for (int i = 0; i < phases[phaseIndex].enemies.Count; i++)
        {
            phases[phaseIndex].enemies[i].Activate();
        }
        if (isBossFight)
        {
            boss.isActivated = true;
        }
        isCounting = false;
        ResetGeneratingBuffsAndDebuffs();
        Invoke("HideTimerText", BeatsManager.instance.beatsTime);
        combo = 0;
        //comboTimer = 0;
        comboTipObject.SetActive(false);
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

    public void OnBeat(int beatIndex)
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
        if (isInPhase && !isCounting && IsInBattlePhase())
        {
            if(generateBuffsTimer >= generateBuffsInterval && phases[phaseIndex].generateBuffsPrefabs.Count > 0 && !IsEnemyClear())
            {
                GenerateBuff();
                generateBuffsInterval = Random.Range(phases[phaseIndex].minGenerateBuffsInterval, phases[phaseIndex].maxGenerateBuffsInterval + 1);
                generateBuffsTimer = 0;
            }
            if(generateDebuffsTimer >= generateDebuffsInterval && phases[phaseIndex].generateDebuffsPrefabs.Count > 0 && !IsEnemyClear())
            {
                GenerateDebuff();
                generateDebuffsInterval = Random.Range(phases[phaseIndex].minGenerateDebuffsInterval, phases[phaseIndex].maxGenerateDebuffsInterval + 1);
                generateDebuffsTimer = 0;
            }
            generateDebuffsTimer++;
            generateBuffsTimer++;
        }
        //comboTimer++;
        //if (comboTimer > 2 && comboTipObject.activeSelf)
        //{
        //    comboTipObject.SetActive(false);
        //    combo = 0;
        //}
    }

    void GenerateBuff()
    {
        if(phases[phaseIndex].generateBuffsPrefabs.Count == 0)
        {
            return;
        }
        float sumWeight = 0;
        for(int i = 0; i< phases[phaseIndex].generateBuffsWeight.Count; i++)
        {
            sumWeight += phases[phaseIndex].generateBuffsWeight[i];
        }
        float buffSeed = Random.Range(0, sumWeight);
        int buffIndex = 0;
        for(int i = 0; i < phases[phaseIndex].generateBuffsWeight.Count; i++)
        {
            buffSeed -= phases[phaseIndex].generateBuffsWeight[i];
            if(buffSeed <= 0)
            {
                buffIndex = i;
                break;
            }
        }
        if(phases[phaseIndex].generateBuffsPositions.Count == 0 
            && GameManager.instance.player.GetComponent<PlayerGridMovement>().xPos == phases[phaseIndex].generateBuffsPositions[0].xPos
            && GameManager.instance.player.GetComponent<PlayerGridMovement>().yPos == phases[phaseIndex].generateBuffsPositions[0].yPos)
        {
            return;
        }
        List<ItemSpawnPosition> tempList = new List<ItemSpawnPosition>();
        for(int i = 0;i< phases[phaseIndex].generateBuffsPositions.Count; i++)
        {
            if(GameManager.instance.player.GetComponent<PlayerGridMovement>().xPos != phases[phaseIndex].generateBuffsPositions[i].xPos
            || GameManager.instance.player.GetComponent<PlayerGridMovement>().yPos != phases[phaseIndex].generateBuffsPositions[i].yPos)
            {
                tempList.Add(phases[phaseIndex].generateBuffsPositions[i]);
            }
        }
        if(tempList.Count == 0)
        {
            return;
        }
        int posSeed = Random.Range(0, tempList.Count);
        GameObject buff = Instantiate(phases[phaseIndex].generateBuffsPrefabs[buffIndex]);
        buff.transform.position = GetPhaseInitialPosition() + new Vector2(tempList[posSeed].xPos * gridSize.x, tempList[posSeed].yPos * gridSize.y);
        buff.GetComponent<BasicBuff>().Setup(tempList[posSeed].xPos, tempList[posSeed].yPos);

        EventInstance itemEmergenceFX;
        itemEmergenceFX = RuntimeManager.CreateInstance(itemEmergenceFXEventPath);
        if (SettingManager.instance != null)
        {
            itemEmergenceFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
        }
        itemEmergenceFX.start();
    }

    void GenerateDebuff()
    {
        if (phases[phaseIndex].generateDebuffsPrefabs.Count == 0)
        {
            return;
        }
        float sumWeight = 0;
        for (int i = 0; i < phases[phaseIndex].generateDebuffsWeight.Count; i++)
        {
            sumWeight += phases[phaseIndex].generateDebuffsWeight[i];
        }
        float buffSeed = Random.Range(0, sumWeight);
        int buffIndex = 0;
        for (int i = 0; i < phases[phaseIndex].generateDebuffsWeight.Count; i++)
        {
            buffSeed -= phases[phaseIndex].generateDebuffsWeight[i];
            if (buffSeed <= 0)
            {
                buffIndex = i;
                break;
            }
        }
        if (phases[phaseIndex].generateBuffsPositions.Count == 0
            && GameManager.instance.player.GetComponent<PlayerGridMovement>().xPos == phases[phaseIndex].generateDebuffsPositions[0].xPos
            && GameManager.instance.player.GetComponent<PlayerGridMovement>().yPos == phases[phaseIndex].generateDebuffsPositions[0].yPos)
        {
            return;
        }
        List<ItemSpawnPosition> tempList = new List<ItemSpawnPosition>();
        for (int i = 0; i < phases[phaseIndex].generateDebuffsPositions.Count; i++)
        {
            if (GameManager.instance.player.GetComponent<PlayerGridMovement>().xPos != phases[phaseIndex].generateDebuffsPositions[i].xPos
            || GameManager.instance.player.GetComponent<PlayerGridMovement>().yPos != phases[phaseIndex].generateDebuffsPositions[i].yPos)
            {
                tempList.Add(phases[phaseIndex].generateDebuffsPositions[i]);
            }
        }
        if (tempList.Count == 0)
        {
            return;
        }
        int posSeed = Random.Range(0, tempList.Count);
        GameObject buff = Instantiate(phases[phaseIndex].generateDebuffsPrefabs[buffIndex]);
        buff.transform.position = GetPhaseInitialPosition() + new Vector2(tempList[posSeed].xPos * gridSize.x, tempList[posSeed].yPos * gridSize.y);
        buff.GetComponent<BasicDebuff>().Setup(tempList[posSeed].xPos, tempList[posSeed].yPos);

        EventInstance itemEmergenceFX;
        itemEmergenceFX = RuntimeManager.CreateInstance(itemEmergenceFXEventPath);
        if (SettingManager.instance != null)
        {
            itemEmergenceFX.setVolume(SettingManager.instance.overAllVolume * SettingManager.instance.soundEffectVolume);
        }
        itemEmergenceFX.start();
    }

    public bool IsInBattlePhase()
    {
        return phases[phaseIndex].isBattlePhase;
    }

    public void UpdateTargetCameraPosition()
    {
        if (!IsInBattlePhase())
        {
            if (!narrativeTip.activeSelf)
            {
                if (GameManager.instance.player.transform.position.x < GetPhaseInitialPosition().x + cameraDistanceToBoundary)
                {
                    targetCameraPos = new Vector3(GetPhaseInitialPosition().x + cameraDistanceToBoundary, 0, cameraObject.transform.position.z);
                }
                else if (GameManager.instance.player.transform.position.x > GetPhaseEndPosition().x - cameraDistanceToBoundary)
                {
                    targetCameraPos = new Vector3(GetPhaseEndPosition().x - cameraDistanceToBoundary, 0, cameraObject.transform.position.z);
                }
                else
                {
                    targetCameraPos = new Vector3(GameManager.instance.player.transform.position.x, 0, cameraObject.transform.position.z);
                }
            }
            else
            {
                if (GameManager.instance.player.transform.position.x < GetPhaseInitialPosition().x + cameraDistanceToBoundary)
                {
                    targetCameraPos = new Vector3(GetPhaseInitialPosition().x + cameraDistanceToBoundary, Mathf.Clamp(GameManager.instance.player.transform.position.y, -1.2f, 0.0f), cameraObject.transform.position.z);
                }
                else if (GameManager.instance.player.transform.position.x > GetPhaseEndPosition().x - cameraDistanceToBoundary)
                {
                    targetCameraPos = new Vector3(GetPhaseEndPosition().x - cameraDistanceToBoundary, Mathf.Clamp(GameManager.instance.player.transform.position.y, -1.2f, 0.0f), cameraObject.transform.position.z);
                }
                else
                {
                    targetCameraPos = new Vector3(GameManager.instance.player.transform.position.x, Mathf.Clamp(GameManager.instance.player.transform.position.y, -1.2f, 0.0f), cameraObject.transform.position.z);
                }
            }
            
        }
        else
        {
            targetCameraPos = new Vector3(GetPhaseInitialPosition().x + cameraDistanceToBoundary, 0, cameraObject.transform.position.z);
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

    public Vector2 GetPhaseInitialPosition(int index)
    {
        Vector2 pos = initialPos;
        for (int i = 0; i < index; i++)
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
                    if (phases[phaseIndex].basicPlatforms[i].GetComponent<BrokenPlatform>() != null)
                    {
                        if (!phases[phaseIndex].basicPlatforms[i].GetComponent<BrokenPlatform>().isBroken)
                        {
                            nextY = phases[phaseIndex].basicPlatforms[i].yPos;
                        }
                    }
                    else
                    {
                        nextY = phases[phaseIndex].basicPlatforms[i].yPos;
                    }
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
                    if (phases[phaseIndex].basicPlatforms[i].GetComponent<BrokenPlatform>() != null)
                    {
                        if (!phases[phaseIndex].basicPlatforms[i].GetComponent<BrokenPlatform>().isBroken)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
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

    public void CheckEnemyCount()
    {
        if (IsInBattlePhase() && !isBossFight)
        {
            int count = 0;
            for (int i = 0; i < phases[phaseIndex].enemies.Count; i++)
            {
                if (phases[phaseIndex].enemies[i].gameObject.activeSelf)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                count -= 1;
                if (count == phases[phaseIndex].enemyBGMChangeCount1 && rageTimer / phases[phaseIndex].rageTime > 0.25f)
                {
                    //Debug.Log("Change1");
                    BeatsManager.instance.SetNormalBGMParameter("TimeNumReact", 1);
                }
                if (count == phases[phaseIndex].enemyBGMChangeCount2 && rageTimer / phases[phaseIndex].rageTime > 0.25f)
                {
                    //Debug.Log("Change2");
                    BeatsManager.instance.SetNormalBGMParameter("TimeNumReact", 2);
                }
            }
        }
    }

    public List<BasicEnemy> GetAllEnemies()
    {
        List<BasicEnemy> tempList = new List<BasicEnemy>();
        for (int i = 0; i < phases[phaseIndex].enemies.Count; i++)
        {
            if (phases[phaseIndex].enemies[i].gameObject.activeSelf)
            {
                tempList.Add(phases[phaseIndex].enemies[i]);
            }
        }
        if (tempList.Count > 0)
        {
            return tempList;
        }
        else
        {
            return null;
        }
    }


    public BasicEnemy GetRandomEnemy()
    {
        List<BasicEnemy> tempList = new List<BasicEnemy>();
        for (int i = 0; i < phases[phaseIndex].enemies.Count; i++)
        {
            if (phases[phaseIndex].enemies[i].gameObject.activeSelf)
            {
                tempList.Add(phases[phaseIndex].enemies[i]);
            }
        }
        if(tempList.Count > 0)
        {
            return tempList[Random.Range(0, tempList.Count)];
        }
        else
        {
            return null;
        }
    }

    public void ShowNextStageIcon()
    {
        nextStageIcon.SetActive(true);
    }

    public void HideNextStageIcon()
    {
        nextStageIcon.SetActive(false);
    }

    public void ShowRecordPanel(float time)
    {
        recordPanel.SetActive(true);
        recordText.text = "Time: " + ((int)time).ToString() + "s";
    }

    public void HideRecordPanel()
    {
        recordPanel.SetActive(false);
    }

    public void AlignObjects()
    {
        for (int i = 0; i < phases.Count; i++)
        {
            phases[i].Initialize();
            for (int j = 0; j < phases[i].basicPlatforms.Count; j++)
            {
                phases[i].basicPlatforms[j].transform.position = GetPhaseInitialPosition(i) + new Vector2(phases[i].basicPlatforms[j].xPos * gridSize.x, phases[i].basicPlatforms[j].yPos * gridSize.y);
                if(phases[i].basicPlatforms[j].sprites.Count > 0)
                {
                    phases[i].basicPlatforms[j].SetSortingOrder(5 + 10 * (4 - phases[i].basicPlatforms[j].yPos));
                }
            }
            for (int j = 0; j < phases[i].enemies.Count; j++)
            {
                phases[i].enemies[j].gameObject.SetActive(true);
                phases[i].enemies[j].transform.position = GetPhaseInitialPosition(i) + new Vector2(phases[i].enemies[j].xPos * gridSize.x, phases[i].enemies[j].yPos * gridSize.y);
            }
            for (int j = 0; j < phases[i].traps.Count; j++)
            {
                phases[i].traps[j].gameObject.SetActive(true);
                phases[i].traps[j].transform.position = GetPhaseInitialPosition(i) + new Vector2(phases[i].traps[j].xPos * gridSize.x, phases[i].traps[j].yPos * gridSize.y);
            }
        }

    }

    public void ReduceRageTime(float value)
    {
        if(rageTimer > 0)
        {
            rageTimer -= value;
            if (rageTimer < 0)
            {
                rageTimer = 0;
            }
        }
    }

    public void DetectDialogTrigger(int x, int y)
    {
        bool isDetected = false;
        for(int i = 0; i < phases[phaseIndex].dialogs.Count; i++)
        {
            if(phases[phaseIndex].dialogs[i]!= null && phases[phaseIndex].dialogs[i].gameObject.activeSelf)
            {
                if (!phases[phaseIndex].dialogs[i].isPlayed)
                {
                    if (phases[phaseIndex].dialogs[i].triggerX == x)
                    {
                        if (!phases[phaseIndex].dialogs[i].isLimitTriggerY || phases[phaseIndex].dialogs[i].triggerY == y)
                        {
                            if (currentDialog != phases[phaseIndex].dialogs[i])
                            {
                                if (phases[phaseIndex].dialogs[i].isLimitTriggerY)
                                {
                                    interactionTip.SetActive(true);
                                    nextDialog = phases[phaseIndex].dialogs[i];
                                }
                                else
                                {
                                    if (currentDialog != null)
                                    {
                                        currentDialog.HideDialogUnits();
                                    }
                                    currentDialog = phases[phaseIndex].dialogs[i];
                                    currentDialog.StartDialogSet();
                                }
                                isDetected = true;
                            }
                        }
                    }
                }
            }
        }
        if (!isDetected && interactionTip.activeSelf)
        {
            interactionTip.SetActive(false);
        }
        if(currentDialog != null)
        {
            if(x < currentDialog.triggerX - 2 || x > currentDialog.triggerX + 2)
            {
                currentDialog.HideDialogUnits();
                currentDialog = null;
            }
        }
    }

    public void StartDialogEvents()
    {
        narrativeTip.SetActive(true);
        BeatsManager.instance.beatsContainer.transform.position = new Vector3(0, -450.0f, 0);
        targetCameraSize = 4.0f;
        nextStageIcon.SetActive(false);
    }

    public void EndDialogEvents()
    {
        narrativeTip.SetActive(false);
        BeatsManager.instance.beatsContainer.transform.position = setAbilities.originalBeatsContainerPosition.position;
        targetCameraSize = 5.0f;
        nextStageIcon.SetActive(true);
    }

    public void AddCombo()
    {
        combo++;
        comboTipObject.SetActive(true);
        comboTipText.text = combo.ToString();
        //comboTimer = 0;
        comboTipText.transform.localScale = new Vector3(2, 2, 2);
    }

    public void EndCombo()
    {
        combo = 0;
        //comboTimer = 0;
        comboTipObject.SetActive(false);
    }

    public void PlayBossEndingCutScene()
    {
        if(bossEndingCutScene != null)
        {
            bossEndingCutScene.Invoke();
        }
    }
}
