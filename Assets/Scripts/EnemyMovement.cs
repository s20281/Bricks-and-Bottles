using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public bool isPatrollingNPC;
    public float speed;
    public Transform groundDetect;

    private Transform player;
    private Animator animator;
    private Rigidbody2D rb;
    public float rayDist;
    private float cooldown = 2;
    private float timeToDie = 2;
    private float attackCooldown = 0;




    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        float firstDistance = Vector3.Distance(player.position, transform.position);
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);

        Walk();

        attackCooldown += Time.deltaTime;

        if (isPatrollingNPC)
        {
            Patrol(groundCheck);
        }

        if (Vector2.Distance(rb.position, player.position) < 7 && Vector2.Distance(rb.position, player.position) >= 2.5)
        {
            Chase(firstDistance);

        }
       

    }

    void Walk()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

    }

    void Chase(float firstDistance)
    {

        float secondDistance = Vector3.Distance(player.position, transform.position);

        if (firstDistance < secondDistance && cooldown <= 0)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed *= -1;
            cooldown = 2;

        }


        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
        rb.MovePosition(newPos);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    { 

        if (attackCooldown >= 0.25)
        {
            attackCooldown = 0;

            if (collision.gameObject.CompareTag("Player"))
            {
                GameEventSystem.Instance.PlayerGetDamage(1);
                animator.SetTrigger("Attack");
            }
        }
    }

    void Patrol(RaycastHit2D groundCheck)
    {
        if (groundCheck == false)
        {
            Debug.Log(groundCheck);
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed *= -1;

        }

    }
}

