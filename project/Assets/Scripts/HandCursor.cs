using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCursor : MonoBehaviour
{
    Vector2 prevMousePos;
    Vector2 pos;

    public Hand hand;

    public float MinMoveRadius = 0.2f;
    public float MaxMoveRadius = 1f;
    private void Start()
    {
        prevMousePos = Input.mousePosition;
    }
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 deltaMousePos = mousePos - prevMousePos;
        pos += deltaMousePos / 100f;

        if (pos.sqrMagnitude > 1) { pos.Normalize(); }



        prevMousePos = mousePos;
    }

    public float GetDirection()
    {
        if (pos.magnitude > MinMoveRadius)
        {
            float crossValue = Vector3.Dot(Vector3.back, Vector3.Cross(hand.transform.localPosition.normalized, pos.normalized));
            if (crossValue > 0)
            {
                return -1f;
                //Debug.Log("right");
            }
            else
            {
                return 1f;
                // Debug.Log("left");
            }
        }
        return 0;
    }
    private void OnDrawGizmos()
    {
        Vector3 playerPos = (Player.Instance != null) ? Player.Instance.transform.position : Vector3.zero;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(playerPos, MaxMoveRadius);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(playerPos, MinMoveRadius);
        Gizmos.color = Color.black;
        Vector3 p = pos;
        Gizmos.DrawSphere(playerPos + p, 0.1f);
    }
}
