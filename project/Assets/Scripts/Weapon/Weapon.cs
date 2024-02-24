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

    public bool AttackDone = false;

    [Range(1f, 20f)]
    public float turnSpeed = 7;

    public void Rotate(RotateDirection rd)
    {
        AttackDone = false;
        _prevLocation = _location;
        if (info != null)
        {
            bool[] attackList = GetAttackRange();
            for (int i = 0; i < attackList.Length; ++i)
            {
                if (attackList[i]) { Attack(i); }
            }
        }
        ChangeLocation();

        bool[] GetAttackRange()
        {
            return info.WpRange[(int)Def.GetAttackRange[_location][rd]].ArrayValue;
        }
        void Attack(int tileNum)
        {
            AttackTileManager.Instance.TileList[tileNum].ChangeColor();
            foreach (var mon in TDMonsterManager.Instance.Monsters)
            {
                if (mon.TileNum == tileNum)
                {
                    mon.Hitted(Damage);
                }
            }
        }
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


    private void Update()
    {
        float angle = Def.WeaponLocationDegree[(int)_location];
        float currAngle = Mathf.Rad2Deg * Mathf.Atan2(transform.position.y, transform.position.x); ;

        Vector3 newPos = Quaternion.Lerp(Quaternion.AngleAxis(currAngle, Vector3.forward), Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * turnSpeed) * new Vector3(WeaponManager.disFromPlayer, 0, 0);

        if ((transform.position - newPos).magnitude < 0.001f)
        {
            AttackDone = true;
        }
        transform.position = newPos;
    }
}
