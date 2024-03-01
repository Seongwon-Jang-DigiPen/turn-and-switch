using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Assets.PixelFantasy.PixelMonsters.Common.Scripts;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    private WeaponLocation _prevLocation = WeaponLocation.Left;
    [SerializeField]
    private WeaponLocation _location = WeaponLocation.Left;
    public WeaponLocation Location { get { return _location; } set { _location = value; } }

    [SerializeField]
    private float _damage;
    public float Damage { get { return _damage; } set { _damage = value; } }
    private float _weight;
    public float Weight { get { return _weight; } set { _weight = value; } }
    public bool IsRotateDone = true;

    public Color color;
    public float turnSpeed => WeaponManager.WeaponTurnSpeed;
    public bool Attackable = false;

    private float _rotateTimer = 0;
    public void Rotate(RotateDirection rd)
    {
        IsRotateDone = false;
        _prevLocation = _location;
        _rotateTimer = 0;
        ChangeLocation();

        void ChangeLocation()
        {
            if (rd == RotateDirection.Clockwise)
            {
                _location = (_location + 1 >= WeaponLocation.Count) ? 0 : _location + 1;
            }
            else
            {
                _location = (_location - 1 < 0) ? WeaponLocation.Count - 1 : _location - 1;
            }
        }
    }


    private void FixedUpdate()
    {
        if (IsRotateDone == false)
        {
            float angle = Def.WeaponLocationDegree[(int)_location];
            float currAngle = Mathf.Rad2Deg * Mathf.Atan2(transform.position.y, transform.position.x);

            Vector3 goalPos = Quaternion.AngleAxis(angle, Vector3.forward) * new Vector3(Def.WeaponPlayerDistance, 0, 0);


            Vector3 newPos = Quaternion.Lerp(Quaternion.AngleAxis(currAngle, Vector3.forward), Quaternion.AngleAxis(angle, Vector3.forward), _rotateTimer) * new Vector3(Def.WeaponPlayerDistance, 0, 0);

            transform.position = newPos;

            if (_rotateTimer >= 1f)
            {
                transform.position = goalPos;
                IsRotateDone = true;
            }
            else
            {
                _rotateTimer += Time.fixedDeltaTime * turnSpeed;
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
}
