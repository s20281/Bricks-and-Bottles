using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float beginTime;

    private void Awake()
    {
        beginTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > beginTime + 10)
        {
            Destroy(gameObject);
        }
    }
}
