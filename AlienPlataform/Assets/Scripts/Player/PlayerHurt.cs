using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    private Collider2D _collider;

    public Action OnHurtEnd = delegate { }; 

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();

        GetComponent<PlayerCheckHurt>().OnSetIsHurt += HurtFall;
    }

    private void HurtFall(bool isHurt)
    {
        _collider.enabled = false;

        OnHurtEnd?.Invoke();
    }

    

}
