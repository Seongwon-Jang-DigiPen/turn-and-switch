using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
  static Player Instance;
  private float _power;
  public float Power { get { return _power; } set { Power = _power; } }

}

