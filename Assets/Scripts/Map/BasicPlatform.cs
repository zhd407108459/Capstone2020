using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlatform : RhythmObject
{
    public int xPos;
    public int yPos;

    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();

    public void SetSortingOrder(int index)
    {
        for(int i = 0; i < sprites.Count; i++)
        {
            sprites[i].sortingOrder = index;
        }
    }
}
