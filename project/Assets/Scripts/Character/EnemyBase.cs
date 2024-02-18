using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : CharacterBase
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    { 
        Debug.Log("Enemy Hitted");
        base.OnTriggerEnter2D(collision);
    }
}
