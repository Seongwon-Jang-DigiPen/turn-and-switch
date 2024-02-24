using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponManager : MonoBehaviour
{

    [SerializeField]
    Weapon[] weapons = new Weapon[(int)WeaponLocation.Count];

    public bool IsAttackDone
    {
        get
        {
            for (int i = 0; i < (int)WeaponLocation.Count; ++i)
            {
                if (weapons[i] != null)
                {
                    if (weapons[i].AttackDone == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    [Range(0, 2f)]
    public float dfp = 1f;

    public static float disFromPlayer = 1f;

    private void Start()
    {
        for (int i = 0; i < (int)WeaponLocation.Count; ++i)
        {
            if (weapons[i] != null)
            {
                weapons[i].Location = (WeaponLocation)i;
                weapons[i].transform.position = Def.WeaponLocationVec2[i];
            }
        }
    }

    private void Update()
    {
        disFromPlayer = dfp;
    }
    public void Rotate(RotateDirection rd)
    {
        RotateWeapon();
        RotateArray();

        void RotateWeapon()
        {
            foreach (Weapon weapon in weapons)
            {
                weapon?.Rotate(rd);
            }
        }

        void RotateArray()
        {
            if (rd == RotateDirection.Clockwise)
            {
                Weapon downWeapon = weapons[(int)WeaponLocation.Down]; // 3
                for (int i = (int)WeaponLocation.Count - 1; i > 0; --i)
                {
                    weapons[i] = weapons[i - 1];
                }
                weapons[(int)WeaponLocation.Left] = downWeapon;
            }
            else
            {
                Weapon leftWeapon = weapons[(int)WeaponLocation.Left];
                for (int i = 0; i < (int)WeaponLocation.Count - 1; ++i)
                {
                    weapons[i] = weapons[i + 1];
                }
                weapons[(int)WeaponLocation.Down] = leftWeapon;
            }
        }
    }

    public bool Rotatable()
    {
        foreach (Weapon weapon in weapons)
        {
            if (weapon != null)
            {
                return false;
            }
        }
        return true;
    }
}
