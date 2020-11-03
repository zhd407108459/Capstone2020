using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDeathBuffParticle : MonoBehaviour
{

    public UnityEvent events;
    public BasicEnemy targetEnemy;

    public float burstDistance;
    public float burstDelay;

    private int isMoveToEnemy;

    private Vector3 burstPosition;
    private GameObject buffIconPrefab;

    void Update()
    {
        if (GameManager.instance.isPaused)
        {
            return;
        }
        if (!targetEnemy.gameObject.activeSelf)
        {
            Destroy(this.gameObject);
        }
        if (isMoveToEnemy == 0)
        {
            transform.position = Vector3.Lerp(transform.position, burstPosition, 15.0f * Time.deltaTime);
            if(Vector3.Distance(transform.position, burstPosition) < 0.02f)
            {
                isMoveToEnemy = 1;
                Invoke("EndBurstDelay", burstDelay);
            }
        }
        else if (isMoveToEnemy == 2)
        {
            transform.position = Vector3.Lerp(transform.position, targetEnemy.transform.position, 15.0f * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetEnemy.transform.position) < 0.02f)
            {
                events.Invoke();
                Instantiate(buffIconPrefab, targetEnemy.transform.position, targetEnemy.transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

    void EndBurstDelay()
    {
        isMoveToEnemy = 2;
    }

    public void SetUp(UnityEvent e, BasicEnemy enemy, GameObject iconPrefab)
    {
        events = e;
        targetEnemy = enemy;
        buffIconPrefab = iconPrefab;
        isMoveToEnemy = 0;
        burstPosition = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
        burstPosition = burstPosition.normalized * burstDistance + transform.position;
    }
}
