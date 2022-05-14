using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleImpact : MonoBehaviour
{
    BoxCollider2D bx;
    public GameObject FirePrefab;
    private void Awake()
    {
        bx = gameObject.GetComponent<BoxCollider2D>();
        //StartCoroutine(ExampleCoroutine());
        bx.enabled = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Instantiate(FirePrefab, gameObject.transform.position+ new Vector3(1,0,0), Quaternion.identity);
        //Instantiate(FirePrefab, gameObject.transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        bx.enabled = true;

    }
}
