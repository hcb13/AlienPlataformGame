using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro ;

public class PlayerGetCoin : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _textMeshPro;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            _textMeshPro.GetComponent<CountingCoins>().IncreaseCoins();
            Destroy(collision.gameObject);
        }
    }
}
