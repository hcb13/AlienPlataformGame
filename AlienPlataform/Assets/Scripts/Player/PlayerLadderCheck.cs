using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadderCheck : MonoBehaviour
{
    public Action OnEnterLadder = delegate { };
    public Action OnExitLadder = delegate { };


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            OnEnterLadder?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            OnExitLadder?.Invoke();
        }
    }

}
