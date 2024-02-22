using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AttackTileManager : MonoBehaviour
{
    static private AttackTileManager _instance;
    static public AttackTileManager Instance { get { return _instance; } }

    public AttackTile[] TileList;

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
}
