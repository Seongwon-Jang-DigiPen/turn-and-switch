using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
  private static Player _instance;
  public static Player Instance { get { return _instance; } }
  private float _power;
  public float Power { get { return _power; } set { Power = _power; } }
  public float Speed = 5;
  private Vector2 _moveDirection;

  private void Start()
  {
    if (_instance != null)
    {
      Debug.LogError("Player MUST BE ONLY ONE OBJECT");
    }
    _instance = this;

  }

  private void Update()
  {
    TempMove();
    Vector3 moveDir = _moveDirection;
    transform.position += moveDir * Speed * Time.deltaTime;
  }

  void TempMove()
  {
    _moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
  }
}

