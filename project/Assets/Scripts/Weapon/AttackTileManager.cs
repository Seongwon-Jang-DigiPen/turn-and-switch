using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AttackTileManager : MonoBehaviour
{
    static private AttackTileManager _instance;
    static public AttackTileManager Instance { get { return _instance; } }

    public AttackTile[] TileList;

    static public AttackTile GetTile(int x, int y)
    {
        return Instance.TileList[y * 5 + x];
    }

    static public AttackTile GetTile(int idx)
    {
        return Instance.TileList[idx];
    }
    static public AttackTile GetTile(Vector2Int pos)
    {
        return GetTile(pos.x, pos.y);
    }
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
