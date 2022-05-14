using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        GameEventSystem.Instance.PlayerFoundCoin();

        PlayerPrefs.SetInt("coin", 1);
        PlayerPrefs.Save();
    }
}
