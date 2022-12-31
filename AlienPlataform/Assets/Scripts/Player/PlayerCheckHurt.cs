using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckHurt : MonoBehaviour
{
    public Action<bool> OnSetIsHurt = delegate { };

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            OnSetIsHurt?.Invoke(true);
        }
    }
}
