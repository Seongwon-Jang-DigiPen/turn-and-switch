using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{

    private Vector2 _moveDir = Vector2.zero;
    private Vector2 _CursorDir = Vector2.zero;
    private bool _grab = false;

    public Vector2 MoveDir { get { return _moveDir; } }
    public Vector2 CursorDir { get { return _CursorDir; } }
    public bool Grab { get { return _grab; } }
    
    public float Speed = 5f;
    private void FixedUpdate()
    { 
        transform.position += (Vector3)_moveDir * Speed * Time.fixedDeltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();
        _moveDir = (inputValue == null) ? Vector2.zero : inputValue;
    }

    public void OnCursorControl(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();
        _CursorDir = (inputValue == null) ? Vector2.zero : inputValue;
    }

    public void OnCursorDeltaControl(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();
        _CursorDir += (inputValue == null) ? Vector2.zero : inputValue / 100f; 
        if (_CursorDir.sqrMagnitude > 1) { _CursorDir.Normalize(); }
    }

    public void OnGrab(InputAction.CallbackContext context)
    {
         _grab = context.performed;
    }
}
