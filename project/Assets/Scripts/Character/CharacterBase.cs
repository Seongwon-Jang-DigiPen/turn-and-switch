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
    public bool IsDead => HP < 0;
    public virtual void Hitted(float damage)
    {
        _hp -= damage;
    }
}
