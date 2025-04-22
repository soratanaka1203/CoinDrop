using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    [SerializeField] GameObject coinPrehub;
    private Vector3 startPos;
    public float scope = 3; //ê∂ê¨Ç∑ÇÈîÕàÕ

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        for(int i = 0; i < 50; i++)
        {
            Debug.Log("ÉRÉCÉìê∂ê¨");
            Instantiate(coinPrehub, startPos + new Vector3(Random.Range(-scope, scope), transform.position.y, Random.Range(-scope, scope)), Quaternion.identity);
        }
    }
}