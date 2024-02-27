using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : CharacterBase
{

  private Vector2 goVec2;
  private Vector2 backVec2;
  private SpriteRenderer _render;

  public float Speed = 1;
  public float PushPower = 10;
  bool _hitable = true;
  private void Start()
  {
    goVec2 = transform.position.normalized;
    goVec2 = -goVec2.normalized;
    backVec2 = -goVec2;
    _render = GetComponent<SpriteRenderer>();
  }
  private void Update()
  {
    if (WeaponManager.Instance.IsShoot == false)
    {
      _hitable = true;
      _render.color = Color.white;
    }
    transform.position += new Vector3(goVec2.x, goVec2.y, 0) * Speed * Time.deltaTime;
  }
  public override void Hitted(float damage)
  {
    if (_hitable == true)
    {
      base.Hitted(damage);

      transform.position += new Vector3(backVec2.x, backVec2.y, 0) * PushPower;
      _render.color = Color.red;
    }
    _hitable = false;
  }
}
