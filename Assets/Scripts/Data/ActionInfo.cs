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
    /// 
    /// 12 boss events
    /// 
    /// 13 doll attack
    /// 
    /// 14 shoot bullet from a position
    /// 
    /// 15 hanging clock by rope
    /// 
    /// 16 shoot reflect bullet from left to right
    /// 17 shoot reflect bullet from right to left
    /// 18 shoot reflect bullet from top to bottom
    /// 19 shoot reflect bullet from bottom to top
    /// 
    /// 20 start boss 3 hook tracking
    /// 
    /// 21 shoot laser horizontal
    /// 22 shoot laser vertical
    /// </summary>
    public List<int> actionParameters = new List<int>();
    /// <summary>
    /// for action 1 - 8 and 16 - 19
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
    /// for action 12
    /// action paramter x = event[x]
    /// 
    /// for action 13 Doll Attack
    /// track player's position automatically
    /// 
    /// for action 14 shoot bullet from a position
    /// action parameter[0] 0 - 7 = direction:
    ///   3  2  1
    ///    \ | /
    ///  4 - * - 0
    ///    / | \
    ///   5  6  7
    /// action parameter[1] == posX
    /// action parameter[2] == posY
    /// 
    /// for action 15 hanging clock by rope
    /// action parameter[0] == time
    /// action parameter[1] == posX
    /// action parameter[2] == posY
    /// action parameter[3] == object index
    /// 
    /// for action 20 start boss 3 hook tracking
    /// no parameter
    /// 
    /// for action 21 and 22
    /// action parameter[0] == pos
    /// 21 horizontal 0-4
    /// 22 vertical 0-9
    /// action parameter[1] == color index
    /// action parameter[2] == length index
    /// 
    /// </summary>
}
