using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottleThrow : MonoBehaviour
{
    
   
    public float recoilForce = 1f;
    public float throwForce = 1f;
    public float cooldown = 1f;
    public GameObject bottlePrefab;
    public GameObject brickPrefab;
    public Slider slider;
    public Image fill;
    public GameObject hand;
    public GameObject holdedWeapon;
    public Sprite brickHolded;
    public Sprite bottleHolded;
    public Sprite brick;
    public Sprite bottle;
    public Image weaponIndicator;
    public GameObject sliderAnchor;

    private GameObject activeWeapon;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Vector3 playerPos;
    private Vector3 mousePos;
    private Vector3 direction;
    private float lastThrowTime;
    private float throwStartTime;
    private bool canThrow;
    private bool charging;
    private bool activeWeaponBrick;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        playerPos = new Vector3(1920/2, 1080*6/20, 0);
        lastThrowTime = Time.time;
        slider.enabled = false;
        slider.gameObject.SetActive(false);
        charging = false;
        activeWeaponBrick = true;
        activeWeapon = brickPrefab;
    }


    void Update()
    {
        mousePos = Input.mousePosition;
        direction = new Vector3(mousePos.x - playerPos.x, mousePos.y - playerPos.y, 0).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        hand.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, angle);
        sliderAnchor.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, angle);

        if (mousePos.x < 1920/2)
        {
            sr.flipX = true;
            //holdedWeapon.GetComponent<SpriteRenderer>().flipY = true;
            
        }
        else
        {
            sr.flipX = false;
            //holdedWeapon.GetComponent<SpriteRenderer>().flipY = false;
        }

        if (Time.time > lastThrowTime + cooldown)
        {
            canThrow = true;            
            holdedWeapon.GetComponent<SpriteRenderer>().enabled = true;
            weaponIndicator.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeWeapon();
        }

        if (Input.GetMouseButtonDown(0) && canThrow)
        {
            slider.gameObject.SetActive(true);
            slider.value = 0f;
            throwStartTime = Time.time;
            charging = true;
        }
        float loadingTime = 0;
        if (canThrow)
        {
            loadingTime = Time.time - throwStartTime;
            slider.value = loadingTime;
        }

        if (Input.GetMouseButtonUp(0) && charging)
        {
            if (loadingTime > 1)
                loadingTime = 1;
            slider.gameObject.SetActive(false);
            ThrowBottle(loadingTime);
            lastThrowTime = Time.time;
            canThrow = false;
            holdedWeapon.GetComponent<SpriteRenderer>().enabled = false;
            charging = false;
        }
    }
    void ThrowBottle(float force)
    {
        force = 0.5f + force / 2;

        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        if(activeWeaponBrick)
            rb.AddForce(-direction * recoilForce * force);
        GameObject bottle = Instantiate(activeWeapon, rb.position, Quaternion.identity);
        bottle.GetComponent<Rigidbody2D>().AddForce(direction * throwForce * force);
        weaponIndicator.enabled = false;
    }

    void ChangeWeapon()
    {
        if(activeWeaponBrick)
        {
            activeWeapon = bottlePrefab;
            holdedWeapon.GetComponent<SpriteRenderer>().sprite = bottleHolded;
            weaponIndicator.sprite = bottle;
        }
        else
        {
            activeWeapon = brickPrefab;
            holdedWeapon.GetComponent<SpriteRenderer>().sprite = brickHolded;
            weaponIndicator.sprite = brick;
        }
        activeWeaponBrick = !activeWeaponBrick;
    }
           
}
