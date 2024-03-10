using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : CharacterBase
{

  Rigidbody2D _rb;
  public float Speed = 1;
  bool _isDead = false;
  private void Start()
  {
    _rb = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {
    if (_isDead == false)
    {
      Vector3 toPlayerVector = Player.Instance.transform.position - transform.position;
      if (toPlayerVector.magnitude <= 1f)
      {
        _rb.velocity = Vector2.zero;
      }
      else
      {
        _rb.velocity = toPlayerVector.normalized * Speed;
      }
    }
  }
  public override void Hitted(float damage)
  {
    base.Hitted(damage);
    _isDead = true;
    Vector3 toMonsterVector = transform.position - Player.Instance.transform.position;
    _rb.AddForce(toMonsterVector.normalized * 10, ForceMode2D.Impulse);
    Destroy(this.gameObject, 2);
  }
}
