using System;
using System.Collections;
using System.Collections.Generic;
using Assets.PixelFantasy.PixelMonsters.Common.Scripts;
using UnityEditor.AnimatedValues;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    public float Damage { get { return _damage; } set { _damage = value; } }
    private float _weight;
    public float Weight { get { return _weight; } set { _weight = value; } }
    public Vector2 StartLocation;
    public float MinDistance = 1;
    public const float MaxDistance = 3.5f;
    public float distance = 0.5f;
    public float Velocity = 0;
    public float Power = 5;
    public float Drag = 5;
    public bool IsShoot = false;
    private void Start()
    {
        StartLocation = transform.position;
    }


    private void FixedUpdate()
    {
        distance += Velocity * Time.fixedDeltaTime;
        if (distance < MinDistance)
        {
            IsShoot = false;
            distance = MinDistance;
            Velocity = 0;
        }
        else if (distance > MaxDistance)
        {
            distance = MaxDistance;
            Velocity = 0;
        }
        Velocity -= Drag * Time.deltaTime;

        transform.localPosition = StartLocation.normalized * distance;
    }
    public void Shoot()
    {
        IsShoot = true;
        Velocity = Power;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster") == true)
        {
            other.GetComponent<EnemyBase>().Hitted(_damage);
            Debug.Log($"Hitted to {other.name}");
        }
    }
}
