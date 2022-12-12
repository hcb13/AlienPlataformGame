using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacingDirection : MonoBehaviour
{

    private bool _facingRight = true;

    public Action<bool> OnFlip = delegate { };

    private void Awake()
    {
        GetComponent<PlayerInput>().OnGetHorizontalInput += SetFacingDirection;
    }

    private void SetFacingDirection(float horizontalInput)
    {
        if (horizontalInput < 0f && _facingRight)
        {
            Flip();
        }
        else if (horizontalInput > 0f && !_facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        OnFlip?.Invoke(_facingRight);
    }

}
