using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryCoin : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -100f)
        {
            Destroy(gameObject);
        }
    }
}
