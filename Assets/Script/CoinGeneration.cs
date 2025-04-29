using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    private Vector3 startPos;
    [SerializeField] private float scope = 1.5f; //ê∂ê¨Ç∑ÇÈîÕàÕ

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        for(int i = 0; i < 200; i++)
        {
            Instantiate(coinPrefab, startPos + new Vector3(Random.Range(-scope, scope), transform.position.y, Random.Range(-scope, scope)), Quaternion.identity);
        }
    }
}