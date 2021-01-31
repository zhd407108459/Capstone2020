using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : RhythmObject
{
    public int delay;
    public int damage;
    public float range;

    public AnimationCurve movementCurve;
    public float movementTime;

    public GameObject bombParticlePrefab;

    private int timer;
    [HideInInspector] public bool isAttacked;
    private bool isToBoss;
    private float movementTimer;

    private Vector3 targetPos;
    private Vector3 startPos;

    void Start()
    {
        
    }

    void Update()
    {
        if (isAttacked && !GameManager.instance.isPaused)
        {
            movementTimer += Time.deltaTime;
            if (Vector2.Distance(transform.position, targetPos) > 0.0001f)
            {
                transform.position = movementCurve.Evaluate(movementTimer / movementTime) * targetPos + (1 - movementCurve.Evaluate(movementTimer / movementTime)) * startPos;
            }
            else
            {
                Instantiate(bombParticlePrefab, transform.position, transform.rotation);
                if (isToBoss)
                {
                    GridManager.instance.boss.TakeDamage(damage);
                }
                Destroy(this.gameObject);
            }
        }
    }

    public void SetUp(int delay, int damage, float range)
    {
        this.delay = delay;
        this.damage = damage;
        this.range = range;
        timer = 0;
    }

    public override void OnBeat(int beatIndex)
    {
        base.OnBeat(beatIndex);
        timer++;
        if(timer == delay && !isAttacked)
        {
            if(Vector2.Distance(GameManager.instance.player.transform.position, this.transform.position) <= range)
            {
                GameManager.instance.player.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            Instantiate(bombParticlePrefab, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    public void AttackedByPlayer(Vector3 target, bool isToBoss)
    {
        isAttacked = true;
        targetPos = target;
        this.isToBoss = isToBoss;
        movementTimer = 0;
        startPos = transform.position;
    }
}
