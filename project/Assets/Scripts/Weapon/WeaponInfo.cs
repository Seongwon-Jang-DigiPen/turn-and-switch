using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[Serializable]
public class WeaponInfo : ScriptableObject
{
    public float Damage = 0;
    public float Weight = 0;
    public Sprite DefaultImage = null;
    public AttackRange[] WpRange = new AttackRange[(int)WeaponRangeDir.Count];

}

