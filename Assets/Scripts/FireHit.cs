using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHit : MonoBehaviour
{
    float nextHitTime;
    int cooldown = 2;

    private void Awake()
    {
        nextHitTime = Time.time + cooldown;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time > nextHitTime)
            {
                GameEventSystem.Instance.PlayerGetDamage(1);
                nextHitTime = Time.time + cooldown;
            }
        }
    }
}
