using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plomiembehavior : MonoBehaviour
{
    float beginTime;
    float nextHitTime;
    int cooldown = 2;

    private void Awake()
    {
        beginTime = Time.time;
        nextHitTime = beginTime + cooldown;

    }

    private void Update()
    {
        if (Time.time > beginTime + 10)
        {
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        //Destroy(gameObject, 0.1f);

            
            
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (Time.time > nextHitTime)
            {
                GameEventSystem.Instance.PlayerGetDamage(1);
                nextHitTime = Time.time + cooldown;
            }
        }
    }
}
