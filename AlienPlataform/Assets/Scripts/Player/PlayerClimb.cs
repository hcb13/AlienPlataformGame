using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{

    private bool _hasEnterLadder = false;
    private Vector2 _vertical;

    private bool _isClimbing = false;

    private Rigidbody2D _rigidbody;
    private float _gravityScale;

    [SerializeField]
    private float speed;

    public Action<bool> OnSetIsClimbing = delegate { };

    private void Awake()
    {
        GetComponent<PlayerInput>().OnGetVerticalInput += SetVertical;

        GetComponent<PlayerLadderCheck>().OnEnterLadder += EnterLadder;
        GetComponent<PlayerLadderCheck>().OnExitLadder += ExitLadder;

        GetComponent<PlayerJump>().OnIsJumpingTrue += ExitLadder;

        _rigidbody = GetComponent<Rigidbody2D>();
        _gravityScale = _rigidbody.gravityScale;
    }

    private void EnterLadder()
    {
        _hasEnterLadder = true;
    }

    private void ExitLadder()
    {
        _hasEnterLadder = false;
        _isClimbing = false;
    }

    private void SetVertical(float vertical)
    {
        _vertical = new Vector2(0f, vertical);

        if (_hasEnterLadder && Mathf.Abs(vertical) > 0f)
        {
            _isClimbing = true;            
        }
    }    

    private void FixedUpdate()
    {
        if (_isClimbing)
        {
            _rigidbody.gravityScale = 0f;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 
                                              _vertical.normalized.y * speed);
        }
        else
        {
            _rigidbody.gravityScale = 1;
        }
    }

    private void LateUpdate()
    {
        OnSetIsClimbing?.Invoke(_isClimbing);
    }

}
