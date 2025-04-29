using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    private int coinCount = 100;
    [SerializeField] TextMeshProUGUI counterText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other);
            coinCount++;
            UpdateText();
        }
    }

    private void UpdateText()
    {
        counterText.text = "Coin:" + coinCount;//UIÇçXêV
    }
}
