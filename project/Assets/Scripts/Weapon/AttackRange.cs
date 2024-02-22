using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttackRange
{
    public bool[] ArrayValue
    {
        get { return _arrayValue; }
        set
        {
            //Debug.Log("Attack Range Change detacted");
            _arrayValue = value;
        }
    }
    private bool[] _arrayValue = new bool[25];
    public bool this[int index]
    {
        get
        {
            return _arrayValue[index];
        }
        set
        {
            //Debug.Log("Attack Range Change detacted");
            _arrayValue[index] = value;
        }
    }
}
