using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    public float Damage { get { return _damage; } set { _damage = value; } }
    private float _weight;
    public float Weight { get { return _weight; } set { _weight = value; } }
    public GameObject owner;
    private void Update()
    {
        if (owner)
        {
            if (owner.GetComponent<Hand>())
            {

                transform.eulerAngles = owner.transform.eulerAngles;
                transform.position = owner.transform.position;
                //transform.position = Pivot.transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            other.GetComponent<EnemyBase>().Hitted(Damage);
        }
    }

    public void Throw(float angularVelocity, float distance, Vector3 dir)
    {
        //GetComponent<Rigidbody2D>().AddForce(dir * power, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().velocity = dir * angularVelocity * distance;
        GetComponent<Rigidbody2D>().AddTorque(angularVelocity, ForceMode2D.Impulse);
    }
}
