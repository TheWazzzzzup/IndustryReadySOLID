using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = nameof(PlayerData))]
public class PlayerData : ScriptableObject
{
    public int IntegerNodesCount { get; private set; } = 2;

    public int BooleanNodesCount { get; private set; } = 10;


    #region Quick&Dirty

    /// <summary>
    /// Changes the integer node count, return true on change and false on failure
    /// </summary>
    /// <param name="increment">The amount you wish to add/subtract from the node count</param>
    /// <returns></returns>
    public bool ChangeIntNodeCountIncrementaly(int increment)
    {
        int x  = IntegerNodesCount + increment;
        if (increment < 0 || x > 99)
        {
            return false;
        }
        else
        {
            IntegerNodesCount += increment;
            return true;
        }
    }

    /// <summary>
    /// Changes the boolean node count, return true on change and false on failure
    /// </summary>
    /// <param name="increment">The amount you wish to add/subtract from the node count</param>
    /// <returns></returns>
    public bool ChangeBoolNodeCountIncrementaly(int increment)
    {
        int x = BooleanNodesCount + increment;
        if (increment < 0 || x > 99)
        {
            return false;
        }
        else
        {
            BooleanNodesCount += increment;
            return true;
        }
    }

    #endregion
}
