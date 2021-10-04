using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserAttack : RhythmObject
{
    public float movementLerpValue;

    public List<Color> laserColors;

    public GameObject sprite;
    public SpriteRenderer indicator;
    public int damage;

    public float targetWidthScale;
    
    public int attackDelay;
    public int stayDelay;

    [HideInInspector] public int xPos;
    [HideInInspector] public int yPos;

    [HideInInspector] public int delayTimer;
    [HideInInspector] public int state;

    private Color indicatorTargetColor;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.isPaused)
        {
            return;
        }
        if (indicator.color.a != indicatorTargetColor.a)
        {
            indicator.color = Color.Lerp(indicator.color, indicatorTargetColor, movementLerpValue * Time.deltaTime);
        }
        if (state == 1)
        {
            sprite.transform.localScale = new Vector3(sprite.transform.localScale.x, Mathf.Lerp(sprite.transform.localScale.y, targetWidthScale, movementLerpValue * Time.deltaTime), sprite.transform.localScale.z);
        }

        if (state == 2)
        {
            sprite.transform.localScale = new Vector3(sprite.transform.localScale.x, Mathf.Lerp(sprite.transform.localScale.y, 0, movementLerpValue * Time.deltaTime), sprite.transform.localScale.z);
            if(sprite.transform.localScale.y < 0.001f)
            {
                Destroy(this.gameObject);
            }
        }

    }

    public override void OnBeat(int beatIndex)
    {
        delayTimer++;
        if (delayTimer >= attackDelay && state == 0)
        {
            indicator.gameObject.SetActive(false);
            state = 1;
            delayTimer = 0;
        }
        if (delayTimer >= stayDelay && state == 1)
        {
            state = 2;
            delayTimer = 0;
        }
    }

    public void SetUp(int x, int y, int damage, int attackDelay, int stayDelay, float rotationZ, int colorIndex)//0 = left to right, 180 = right to left, 90 = bottom to top, 270 = top to bottom
    {
        xPos = x;
        yPos = y;
        transform.position = GridManager.instance.GetPhaseInitialPosition() + new Vector2(xPos * GridManager.instance.gridSize.x, yPos * GridManager.instance.gridSize.y);
        this.damage = damage;
        this.attackDelay = attackDelay;
        this.stayDelay = stayDelay;
        delayTimer = 0;
        state = 0;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        sprite.transform.localScale = new Vector3(sprite.transform.localScale.x, 0.000001f, sprite.transform.localScale.z);
        if(colorIndex < laserColors.Count)
        {
            sprite.GetComponent<SpriteRenderer>().color = laserColors[colorIndex];
        }
        else
        {
            sprite.GetComponent<SpriteRenderer>().color = Color.white;
        }

        indicator.gameObject.SetActive(true);
        indicatorTargetColor = indicator.color;
        indicator.color = new Color(indicator.color.r, indicator.color.g, indicator.color.b, 0);
    }
}
