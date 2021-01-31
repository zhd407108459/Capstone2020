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
    /// 9 show boss components
    /// 
    /// 10 throw bomb
    /// 
    /// 11 shoot bullet from center
    /// </summary>
    public List<int> actionParameters = new List<int>();
    /// <summary>
    /// for action 1 - 8
    /// position left -> right 0-9
    /// position bottom -> top 0-4
    /// 
    /// for action 9
    /// action parameter = component index
    /// 
    /// for action 10
    /// action parameter = position index
    /// 
    /// for action 11
    /// action parameter 0 - 7 = direction:
    ///   3  2  1
    ///    \ | /
    ///  4 - * - 0
    ///    / | \
    ///   5  6  7
    ///   
    /// </summary>
}
