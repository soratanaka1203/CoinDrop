using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    public int coinCount { get; private set; } = 100 ;//�O������擾�����ł���
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

    public void DecreaseCoin()
    {
        coinCount--;
        UpdateText();
    }

    private void UpdateText()
    {
        counterText.text = "Coin:" + coinCount;//UI���X�V
    }
}
