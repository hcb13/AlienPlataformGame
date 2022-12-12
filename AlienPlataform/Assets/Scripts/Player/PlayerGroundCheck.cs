using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float groundCheckRadius;

    public Action<bool> OnGetIsGrounded = delegate { };


    private void Update()
    {
        OnGetIsGrounded?.Invoke( Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) );
    }


}
