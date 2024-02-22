using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public WeaponInfo info;
    private WeaponLocation _prevLocation = WeaponLocation.Left;
    [SerializeField]
    private WeaponLocation _location = WeaponLocation.Left;
    public WeaponLocation Location { get { return _location; } set { _location = value; } }
    private float _damage;
    public float Damage { get { return _damage; } set { _damage = value; } }
    private float _weight;
    public float Weight { get { return _weight; } set { _weight = value; } }

    [Range(1f, 20f)]
    public float turnSpeed = 7;

    public void Rotate(RotateDirection rd)
    {
        _prevLocation = _location;
        if (info != null)
        {
            // Debug.Log($"Rotate: {rd}");
            // Debug.Log($"Location: {_location}");
            // Debug.Log($"AttackRange: {Def.GetAttackRange[_location][rd]}");
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
        //transform.position = WeaponManager.WeaponLocationVec2[(int)_location];
        // Vector2 from = WeaponManager.WeaponLocationVec2[(int)_prevLocation];
        // float fromAngle = Mathf.Atan2(from.y, from.x); //원래는 플레이어의 위치값만큼 빼야 함
        // Vector2 to = WeaponManager.WeaponLocationVec2[(int)_location];
        // float toAngle = Mathf.Atan2(to.y, to.x);

        float angle = Def.WeaponLocationDegree[(int)_location]; //Mathf.Lerp(WeaponManager.WeaponLocationDegree[(int)_prevLocation], WeaponManager.WeaponLocationDegree[(int)_location], rotateTime);
        float prevAngle = Mathf.Rad2Deg * Mathf.Atan2(transform.position.y, transform.position.x); ;
        //Vector3 newPos = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;

        Vector3 newPos = Quaternion.Lerp(Quaternion.AngleAxis(prevAngle, Vector3.forward), Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * turnSpeed) * new Vector3(WeaponManager.disFromPlayer, 0, 0);

        transform.position = newPos;

    }

    public bool Rotatable()
    {
        return true;
    }
}
