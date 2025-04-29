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

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(x, 0, 0);//横移動
        float input = Input.GetAxis("Vertical") * (moveSpeed * 5)* Time.deltaTime;
        RotateWithLimit(input);//角度を変更


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

    private void RotateWithLimit(float input)
    {
        // 現在の回転を取得
        Vector3 angles = transform.eulerAngles;

        // 角度を-180〜180に変換
        float xAngle = angles.x;
        if (xAngle > 180f) xAngle -= 360f;

        // 入力に応じて回転
        xAngle += input;

        // 角度制限
        xAngle = Mathf.Clamp(xAngle, -30, 90);

        // 回転を適用
        transform.eulerAngles = new Vector3(xAngle, angles.y, angles.z);
    }
}
