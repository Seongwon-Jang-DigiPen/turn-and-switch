using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackRange
{
    public bool[] ArrayValue = new bool[25];
    public bool this[int index]
    {
        get
        {
            return ArrayValue[index];
        }
        set
        {
            //Debug.Log("Attack Range Change detacted");
            ArrayValue[index] = value;
        }
    }
}
