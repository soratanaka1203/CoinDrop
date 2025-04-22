using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float amplitude = 1.5f; // ������
    [SerializeField] private float frequency = 0.75f; // ��������

    private Vector3 startPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float z = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPos + new Vector3(0, 0, z);
    }
}
