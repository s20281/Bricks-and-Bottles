using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public int lives;
    public bool coin;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        coin = false;
        PlayerPrefs.SetInt("coin", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChangeHealth(int change)
    {
        lives += change;

        if (lives < 1)
            return true;
        return false;
    }

    public void coinFound()
    {
        coin = true;
    }
}
