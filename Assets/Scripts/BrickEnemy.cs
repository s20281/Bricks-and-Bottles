using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickEnemy : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEventSystem.Instance.PlayerGetDamage(1);
        }

        if (gameObject.CompareTag("Brick"))
        {
            Destroy(gameObject);
        }
    }
}
