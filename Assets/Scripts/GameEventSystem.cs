using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventSystem : MonoBehaviour
{
    private static GameEventSystem instance;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public static GameEventSystem Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameEventSystem>();
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public GameData data;


    public event Action<GameData> OnPlayerGetDamage;

    public void PlayerGetDamage(int damage)
    {
        bool playerIsDead = data.ChangeHealth(-damage);

        if (playerIsDead)
            SceneManager.LoadScene("GAMEOVER");

        player.GetComponent<Animator>().SetTrigger("isHurt");
        OnPlayerGetDamage?.Invoke(data);
    }

    public void PlayerFoundCoin()
    {
        data.coinFound();
    }

    public bool hasPlayerFoundCoin()
    {
        return data.coin;
    }

}
