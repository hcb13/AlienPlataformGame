using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action<float> OnGetHorizontalInput = delegate { };
    public Action<float> OnGetVerticalInput = delegate { };
    public Action<bool> OnGetButtonDownJump = delegate { };
    
    private void Update()
    {

        OnGetHorizontalInput?.Invoke( Input.GetAxisRaw("Horizontal") );
        OnGetVerticalInput?.Invoke(Input.GetAxisRaw("Vertical"));

        OnGetButtonDownJump?.Invoke(Input.GetButtonDown("Jump"));

    }

}
