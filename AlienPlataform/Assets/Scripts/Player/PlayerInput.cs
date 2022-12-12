using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action<float> OnGetHorizontalInput = delegate { };
    public Action<bool> OnGetButtonDownJump = delegate { };
    
    private void Update()
    {

        OnGetHorizontalInput?.Invoke( Input.GetAxisRaw("Horizontal") );
        OnGetButtonDownJump?.Invoke(Input.GetButtonDown("Jump"));

    }

}
