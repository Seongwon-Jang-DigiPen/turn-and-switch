using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerRotate : MonoBehaviour
{

    // [SerializeField] private float Velocity = 0;
    // [SerializeField] private float _maxVelocity = 200;
    // [SerializeField] private float acceleration = 180;
    // //drag only concered when player isn't rotate;
    // [SerializeField] private float _drag = 5;


    // private void FixedUpdate()
    // {
    //     transform.rotation = Quaternion.Euler(transform.eulerAngles + (Vector3.forward * Velocity));

    //     if (WeaponManager.Instance.IsRotate == false || WeaponManager.Instance.IsReverseRotate == true)
    //     {
    //         if (Velocity > 0)
    //         {
    //             if (Velocity - Time.fixedDeltaTime * _drag < 0 && WeaponManager.Instance.IsReverseRotate == false)
    //             {
    //                 Velocity = 0;
    //                 return;
    //             }
    //             Velocity -= Time.fixedDeltaTime * _drag;
    //         }
    //         else if (Velocity < 0)
    //         {
    //             if (Velocity + Time.fixedDeltaTime * _drag > 0 && WeaponManager.Instance.IsReverseRotate == false)
    //             {
    //                 Velocity = 0;
    //                 return;
    //             }
    //             Velocity += Time.fixedDeltaTime * _drag;
    //         }
    //     }
    // }

    // void RotateWeapon(RotateDirection rd)
    // {
    //     Velocity += acceleration * GetSign(rd) * Time.deltaTime;
    //     WeaponManager.Instance.IsReverseRotate = (Velocity > 0 && GetSign(rd) < 0) || (Velocity < 0 && GetSign(rd) > 0);
    //     Velocity = Mathf.Max(-_maxVelocity, Mathf.Min(Velocity, _maxVelocity));

    // }

    // public int GetSign(RotateDirection rd)
    // {
    //     return (rd == RotateDirection.Clockwise) ? 1 : -1;
    // }
}
