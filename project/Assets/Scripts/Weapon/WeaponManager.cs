using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class WeaponManager : MonoBehaviour
{

    private static WeaponManager _instance;
    public static WeaponManager Instance { get { return _instance; } }

    [SerializeField] private float _maxVelocity = 200;
    [SerializeField] private float acceleration = 180;
    //drag only concered when player isn't rotate;
    [SerializeField] private float _drag = 5;
    [SerializeField] Weapon[] weapons = new Weapon[(int)WeaponLocation.Count];
    private RotateDirection _prevRotateDirection = RotateDirection.Clockwise;
    private Rigidbody2D _rb;
    public bool IsRotate = false;
    public bool IsReverseRotate = false;

    public bool IsShoot
    {
        get
        {
            foreach (Weapon wp in weapons)
            {
                if (wp.IsShoot == true) return true;
            }
            return false;
        }
    }

    public float dis = 1;
    private void Start()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsRotate == false || IsReverseRotate == true)
        {
            _rb.angularDrag = _drag;
        }
        else
        {

            _rb.angularDrag = 0;
        }
    }

    public void ShootWeapon()
    {
        foreach (Weapon wp in weapons)
        {
            wp.Shoot();
        }
    }

    public void Rotate(RotateDirection rd)
    {
        RotateWeapon();

        void RotateWeapon()
        {
            IsReverseRotate = (_rb.angularVelocity > 0 && GetSign(rd) < 0) || (_rb.angularVelocity < 0 && GetSign(rd) > 0);
            _rb.AddTorque(acceleration * Time.deltaTime * GetSign(rd), ForceMode2D.Force);

            if (GetSign(rd) > 0)
            {
                _rb.angularVelocity = Mathf.Min(_rb.angularVelocity, _maxVelocity);
            }
            else
            {
                _rb.angularVelocity = Mathf.Max(_rb.angularVelocity, -_maxVelocity);
            }
        }
    }

    public int GetSign(RotateDirection rd)
    {
        return (rd == RotateDirection.Clockwise) ? -1 : 1;
    }
}
