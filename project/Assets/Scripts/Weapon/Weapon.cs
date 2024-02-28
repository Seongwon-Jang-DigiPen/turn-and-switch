using System;
using System.Collections;
using System.Collections.Generic;
using Assets.PixelFantasy.PixelMonsters.Common.Scripts;
using UnityEditor.AnimatedValues;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public WeaponInfo info;
    private WeaponLocation _prevLocation = WeaponLocation.Left;
    [SerializeField]
    private WeaponLocation _location = WeaponLocation.Left;
    public WeaponLocation Location { get { return _location; } set { _location = value; } }

    [SerializeField]
    private float _damage;
    public float Damage { get { return _damage; } set { _damage = value; } }
    private float _weight;
    public float Weight { get { return _weight; } set { _weight = value; } }

    public Color color;

    [Range(1f, 20f)]
    public float turnSpeed = WeaponManager.WeaponTurnSpeed;
    public bool Attackable = false;
    public void Rotate(RotateDirection rd)
    {
        _prevLocation = _location;

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

    public void Attack()
    {
        bool[] range = info?.WpRange?.GetRange(Location);
        if (range != null)
        {
            for (int i = 0; i < range.Length; ++i)
            {
                if (range[i]) { TileCheck(i); }
            }
        }

        void TileCheck(int tileNum)
        {
            AttackTileManager.Instance.TileList[tileNum].ChangeColor(color);
            foreach (var mon in TDMonsterManager.Instance.Monsters)
            {
                if (mon.TileNum == tileNum)
                {
                    mon.Hitted(Damage);
                }
            }
        }
    }

    private void Update()
    {
        float angle = Def.WeaponLocationDegree[(int)_location];
        float currAngle = Mathf.Rad2Deg * Mathf.Atan2(transform.position.y, transform.position.x); ;

        Vector3 newPos = Quaternion.Lerp(Quaternion.AngleAxis(currAngle, Vector3.forward), Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * turnSpeed) * new Vector3(Def.WeaponPlayerDistance, 0, 0);

        transform.position = newPos;
    }
}
