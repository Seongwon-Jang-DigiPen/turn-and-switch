using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponManager : MonoBehaviour
{

    private static WeaponManager _instance;
    public static WeaponManager Instance { get { return _instance; } }
    [SerializeField]
    Weapon[] _weapons = new Weapon[(int)WeaponLocation.Count];



    [Range(5f, 15f)]
    public static float WeaponTurnSpeed = 5f;

    private void Start()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        for (int i = 0; i < (int)WeaponLocation.Count; ++i)
        {
            if (_weapons[i] != null)
            {
                _weapons[i].Location = (WeaponLocation)i;
                _weapons[i].transform.position = Def.WeaponLocationVec2[i];
            }
        }
    }

    public void Rotate(RotateDirection rd)
    {
        RotateWeapon();
        RotateArray();

        void RotateWeapon()
        {
            foreach (Weapon weapon in _weapons)
            {
                weapon?.Rotate(rd);
            }
        }

        void RotateArray()
        {
            if (rd == RotateDirection.Clockwise)
            {
                Weapon lastWeapon = _weapons[(int)WeaponLocation.Count - 1]; // 3
                for (int i = (int)WeaponLocation.Count - 1; i > 0; --i)
                {
                    _weapons[i] = _weapons[i - 1];
                }
                _weapons[0] = lastWeapon;
            }
            else
            {
                Weapon firstWeapon = _weapons[0];
                for (int i = 0; i < (int)WeaponLocation.Count - 1; ++i)
                {
                    _weapons[i] = _weapons[i + 1];
                }
                _weapons[(int)WeaponLocation.Count - 1] = firstWeapon;
            }
        }
    }

    public bool IsRotateable()
    {
        for (int i = 0; i < _weapons.Length; ++i)
        {
            if (_weapons[i] != null && _weapons[i].IsRotateDone == false)
            {
                return false;
            }
        }
        return true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(Vector3.zero, 1);

        for (int i = 0; i < 8; ++i)
        {
            Gizmos.DrawLine(Vector3.zero, Quaternion.AngleAxis(45 * i, Vector3.forward) * new Vector3(100, 0, 0));
        }
    }
}
