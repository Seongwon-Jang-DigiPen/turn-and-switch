using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDMonsterManager : MonoBehaviour
{
    public TDMonster[] Monsters
    {
        get
        {
            return FindObjectsOfType<TDMonster>();
        }
    }

    private static TDMonsterManager _instance;
    public static TDMonsterManager Instance { get { return _instance; } }

    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool IsActionDone()
    {
        foreach (var mon in Monsters)
        {
            if (mon.IsActionDone == false)
                return false;
        }
        return true;
    }
}
