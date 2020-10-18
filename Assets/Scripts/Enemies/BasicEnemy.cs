using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : RhythmObject
{
    public bool isActivated;

    public int xPos;
    public int yPos;

    public void Activate()
    {
        isActivated = true;
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
    }
}
