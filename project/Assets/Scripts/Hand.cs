using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float RotationSpeed = 100;
    public float playerHandDistance = 0.7f;

    private bool isMousePressed = false;
    private bool wasMousePressed = false;
    private float _rotateVelocity = 0;
    public float MaxRoteVelocity = 360;
    public float acceleration = 180;
    private Weapon weapon;
    private Weapon hovering;

    public float throwPower = 10;
    private void Update()
    {
        isMousePressed = Input.GetMouseButton(0);
        if (weapon != null && isMousePressed == true)
        {
            GrabWeaponUpdate();
        }
        else if (weapon != null && isMousePressed == false && wasMousePressed == true)
        {
            ThrowWeapon();
        }
        else if (weapon == null && isMousePressed == true && wasMousePressed == false)
        {
            CatchWeapon();
        }
        else
        {
            UnGrabWeaponUpdate();
        }
        wasMousePressed = isMousePressed;

        void GrabWeaponUpdate()
        {
            float currAngle = Mathf.Rad2Deg * Mathf.Atan2(transform.localPosition.y, transform.localPosition.x);

            _rotateVelocity += FindAnyObjectByType<HandCursor>().GetDirection() * acceleration * Time.deltaTime;

            _rotateVelocity = Mathf.Min(MaxRoteVelocity, Mathf.Max(-MaxRoteVelocity, _rotateVelocity));

            currAngle += _rotateVelocity * Time.deltaTime;

            transform.eulerAngles = new Vector3(0, 0, currAngle);
            transform.localPosition = Quaternion.AngleAxis(currAngle, Vector3.forward) * new Vector3(playerHandDistance, 0, 0);

        }

        void UnGrabWeaponUpdate()
        {
            Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursor.z = 0;
            transform.localPosition = (cursor - transform.parent.position).normalized * playerHandDistance;
        }

        // 마우스 버튼이 떼졌을 때
        if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
        }
    }

    void CatchWeapon()
    {
        if (hovering != null)
        {
            weapon = hovering;

            hovering.GetComponent<Weapon>().owner = this.gameObject;
        }
    }

    void ThrowWeapon()
    {
        float currAngle = Mathf.Rad2Deg * Mathf.Atan2(transform.localPosition.y, transform.localPosition.x);

        weapon.Throw(_rotateVelocity * Mathf.Deg2Rad,
        playerHandDistance,
        Quaternion.AngleAxis(currAngle + FindAnyObjectByType<HandCursor>().GetDirection() * ((_rotateVelocity > 0) ? 90 : -90), Vector3.forward) * Vector3.right);
        weapon.owner = null;
        weapon = null;
        hovering = null;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (hovering == null && other.GetComponent<Weapon>() != null)
        {
            hovering = other.GetComponent<Weapon>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (hovering != null && other.GetComponent<Weapon>() == hovering)
        {
            hovering = null;
        }
    }
}
