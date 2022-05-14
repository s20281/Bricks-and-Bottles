using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextSceneSript : MonoBehaviour
{
    float cooldown = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            SceneManager.LoadScene("Park");
        }
        
    

    if(Input.GetKeyDown("space")){

            SceneManager.LoadScene("Park");

        }
    
    }
}
