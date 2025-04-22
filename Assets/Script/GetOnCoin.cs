using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GetOnCoin : MonoBehaviour
{
    [SerializeField] Transform parentTarget;//�e�I�u�W�F�N�g

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.transform.SetParent(parentTarget);//�e�q�֌W�ɂ���
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            other.transform.SetParent(null);//�֌W����
        }
    }
}
