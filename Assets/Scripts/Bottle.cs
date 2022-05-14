using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public float rotSpeed = 1f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 0, rotSpeed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject, 2);
    }
}
