using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountingCoins : MonoBehaviour
{
    
    private TMPro.TextMeshProUGUI _textMeshPro;

    private int qtdCoins = 0;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void IncreaseCoins()
    {
        qtdCoins += 1;
        _textMeshPro.text = qtdCoins.ToString();
    }
}
