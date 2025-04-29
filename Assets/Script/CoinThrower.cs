using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CoinThrower : MonoBehaviour
{
    [SerializeField] private CoinCollector collector;
    [SerializeField] private float moveSpeed = 0.5f;

    [SerializeField] private GameObject coinPrefab; // ��΂��R�C����Prefab
    [SerializeField] private Transform throwPoint;  // �R�C���𔭎˂���ʒu
    [SerializeField] private float throwForce = 10f; // �������
    [SerializeField] private float throwInterval = 0.3f; // �A�ˊԊu�i�b�j

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
            Vector3 throwDirection = transform.forward + transform.up; // �΂ߏ�ɔ�΂�
            rb.AddForce(throwDirection.normalized * throwForce, ForceMode.Impulse);
        }

        collector.DecreaseCoin(); // �R�C�������炷
    }
}
