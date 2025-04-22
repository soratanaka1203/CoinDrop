using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetOnCoin : MonoBehaviour
{
    [SerializeField] Transform parentTarget;//親オブジェクト

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.transform.SetParent(parentTarget);//親子関係にする
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.transform.SetParent(null);//関係解除
        }
    }
}
