using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
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

    [HideInInspector] public Vector3 targetCameraPos;
    [HideInInspector] public bool isCameraFollowing;
    [HideInInspector] public bool isInPhase;

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
            isInPhase = true;
            if (!IsInBattlePhase())
            {
                isCameraFollowing = true;
            }
            GameManager.instance.player.GetComponent<PlayerGridMovement>().SetPos(0, GameManager.instance.player.GetComponent<PlayerGridMovement>().yPos);
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
                if (phases[phaseIndex].basicPlatforms[i].posX == x && phases[phaseIndex].basicPlatforms[i].posY > nextY && phases[phaseIndex].basicPlatforms[i].posY <= y)
                {
                    nextY = phases[phaseIndex].basicPlatforms[i].posY;
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
                if (phases[phaseIndex].basicPlatforms[i].posX == x && phases[phaseIndex].basicPlatforms[i].posY == y)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
