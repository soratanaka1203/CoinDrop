using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CoinThrower : MonoBehaviour
{
    [SerializeField] private CoinCollector collector;
    [SerializeField] private float moveSpeed = 0.5f;

    [SerializeField] private GameObject coinPrefab; // 飛ばすコインのPrefab
    [SerializeField] private Transform throwPoint;  // コインを発射する位置
    [SerializeField] private float throwForce = 10f; // 投げる力
    [SerializeField] private float throwInterval = 0.3f; // 連射間隔（秒）

    private Coroutine throwCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        transform.position += new Vector3(x, 0, 0) * moveSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (throwCoroutine == null)
            {
                throwCoroutine = StartCoroutine(ThrowCoins());
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (throwCoroutine != null)
            {
                StopCoroutine(throwCoroutine);
                throwCoroutine = null;
            }
        }
    }

    private IEnumerator ThrowCoins()
    {
        while (true)
        {
            ThrowCoin();
            yield return new WaitForSeconds(throwInterval);
        }
    }

    private void ThrowCoin()
    {
        if (collector.coinCount <= 0)
            return;

        GameObject coin = Instantiate(coinPrefab, throwPoint.position, Quaternion.identity);

        Rigidbody rb = coin.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 throwDirection = transform.forward + transform.up; // 斜め上に飛ばす
            rb.AddForce(throwDirection.normalized * throwForce, ForceMode.Impulse);
        }

        collector.DecreaseCoin(); // コインを減らす
    }
}
