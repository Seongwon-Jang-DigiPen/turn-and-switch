using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponManager : MonoBehaviour
{

    [SerializeField]
    Weapon[] _weapons = new Weapon[(int)WeaponLocation.Count];

    [Range(5f, 15f)]
    public static float WeaponTurnSpeed = 10f;

    private void Start()
    {
        for (int i = 0; i < (int)WeaponLocation.Count; ++i)
        {
            if (_weapons[i] != null)
            {
                _weapons[i].Location = (WeaponLocation)i;
                _weapons[i].transform.position = Def.WeaponLocationVec2[i];
            }
        }
    }

    private void Update()
    {
    }

    public void Attack()
    {
        foreach (Weapon wp in _weapons)
        {
            wp?.Attack();
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

    // public bool Rotatable()
    // {
    //     foreach (Weapon weapon in _weapons)
    //     {
    //         if (weapon != null)
    //         {
    //             return false;
    //         }
    //     }
    //     return true;
    // }

    public bool Attackable()
    {
        foreach (Weapon weapon in _weapons)
        {
            if (weapon?.Attackable == false)
            {
                return false;
            }
        }
        return true;
    }

}
