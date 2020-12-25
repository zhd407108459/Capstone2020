using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInfo
{
    public int actionType;
    /// <summary>
    /// 1 shoot bullet from left to right
    /// 2 shoot bullet from right to left
    /// 3 shoot bullet from top to bottom
    /// 4 shoot bullet from bottom to top
    /// 
    /// 5 solid attack from left to right
    /// 6 solid attack from right to left
    /// 7 solid attack from top to bottom
    /// 8 solid attack from bottom to top
    /// 
    /// 
    /// </summary>
    public List<int> actionParameters = new List<int>();
    /// <summary>
    /// for action 1 - 8
    /// position left -> right 0-9
    /// position bottom -> top 0-4
    /// </summary>
}
