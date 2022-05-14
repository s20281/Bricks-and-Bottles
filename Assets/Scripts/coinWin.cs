using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinWin : MonoBehaviour
{
    GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        int coinInt = PlayerPrefs.GetInt("coin");

        if (coinInt == 1)
            coin.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
