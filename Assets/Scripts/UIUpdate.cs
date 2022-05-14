using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdate : MonoBehaviour
{
    public Sprite lives3;
    public Sprite lives2;
    public Sprite lives1;
    public Sprite lives0;

    public Image health;

    private void Start()
    {
        health.sprite= lives3;
        GameEventSystem.Instance.OnPlayerGetDamage += HealthUpdate;
    }

    void HealthUpdate(GameData data)
    {
        switch(data.lives)
        {
            case 3:
                health.sprite = lives3;
                break;
            case 2:
                health.sprite = lives2;
                break;
            case 1:
                health.sprite = lives1;
                break;
            case 0:
                health.sprite = lives0;
                break;
        }
    }
}
