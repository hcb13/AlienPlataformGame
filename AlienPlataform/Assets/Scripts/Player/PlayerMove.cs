using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.5f;

    private Vector2 _movement;
    private Rigidbody2D _rigidbody;

    public Action<bool> OnSetIdle = delegate { };
    
    private void Awake()
    {
        GetComponent<PlayerInput>().OnGetHorizontalInput += SetMovement;        

        _rigidbody = GetComponent<Rigidbody2D>();        
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_movement.normalized.x * speed,
                                         _rigidbody.velocity.y);
    }

    private void LateUpdate()
    {
        OnSetIdle?.Invoke(_movement == Vector2.zero);
    }

    private void SetMovement(float horizontalInput)
    {
        _movement = new Vector2(horizontalInput, 0f);
    }
    
}
