using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class CharacterBase : MonoBehaviour
{
    [SerializeField]
    protected float _hp = 100;
    public float HP { get { return _hp; } set { _hp = value; } }
    private float _maxHp = 100f;
    public float MaxHp { get { return _maxHp; } }

    private Vector2Int tilePos = new Vector2Int(0, 0);
    public Vector2Int TilePos { get { return tilePos; } protected set { tilePos = value; } }
    public int TileNum => TilePos.x + TilePos.y * 5;
    public bool IsDead => HP < 0;
    public virtual void Hitted(float damage)
    {
        _hp -= damage;
    }
}
