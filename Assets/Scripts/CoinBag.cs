using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinBag : MonoBehaviour
{
    public int cantidad = 0;
    public TMP_Text coinNumbers;

    private void FixedUpdate()
    {
        coinNumbers.text = cantidad.ToString();
    }
}
