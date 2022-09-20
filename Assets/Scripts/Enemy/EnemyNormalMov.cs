using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormalMov : MonoBehaviour
{
    Transform playerPos;
    Animator animator;
    bool idle;
    float timer;
    bool attack;
    bool death;
    ExpPlayer exp;
    [SerializeField] Transform uiBarHealth;
    Rigidbody2D body;
    PlayerController playerController;
    VidaPlayer playerVida;
    [SerializeField] Damage control;

    public int maxHealt;
    public float health;
    public float cant;
    public float speed;
    public float distStop;
    public float distBack;
    public float distAttack;
    public bool destroy;

    public int damage;
    public int porcent;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        exp = GameObject.FindGameObjectWithTag("Player").GetComponent<ExpPlayer>();
        body = GetComponent<Rigidbody2D>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerVida = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaPlayer>();

        AsignarDaño();
    }

    private void Update()
    {
        if (!death)
        {
            //Movement
            if (Vector2.Distance(transform.position, playerPos.position) < distStop)
            {
                Vector2 pos = Vector2.MoveTowards(body.position, playerPos.position, speed * Time.deltaTime);
                body.MovePosition(pos);
                idle = false;
            }

            if (Vector2.Distance(transform.position, playerPos.position) < distBack)
            {
                Vector2 pos = Vector2.MoveTowards(body.position, playerPos.position, -speed * Time.deltaTime);
                body.MovePosition(pos);
                idle = false;
            }

            if (Vector2.Distance(transform.position, playerPos.position) > distStop)
            {
                idle = true;
            }

            //Attack
            if (Vector2.Distance(transform.position, playerPos.position) < distAttack && attack)
            {
                animator.SetTrigger("Attack");
                timer = 0;
            }

            if (timer < cant)
            {
                attack = false;
                timer += Time.deltaTime;
                if (timer >= cant)
                {
                    timer = Time.deltaTime;
                    attack = true;
                }
            }

            //Flip
            if (playerPos.position.x > this.transform.position.x)
            {
                this.transform.localScale = new Vector2(1, 1);
            }
            else
            {
                this.transform.localScale = new Vector2(-1, 1);
            }

            RefresBar();

        }

        if (health <= 0)
        {
            death = true;
        }

        if (destroy)
        {
            LogicaExp();
            Destroy(gameObject);
        }
    }

    public void AsignarDaño()
    {
        int htlPlayer = playerVida.health;
        damage = porcent * htlPlayer / 100;
        control.daño = damage;
    }

    void RefresBar()
    {
        float healthBar = (float)health / (float)maxHealt;
        uiBarHealth.localScale = Vector3.Lerp(uiBarHealth.localScale, new Vector3(healthBar, 1, 1), Time.deltaTime * 9f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PosArma"))
        {
            animator.SetTrigger("Hit");
            health -= playerController.daño;
        }

        if (collision.CompareTag("Bullet")) 
        {
            animator.SetTrigger("Hit");
        }
    }

    private void FixedUpdate()
    {
        animator.SetBool("Idle", idle);
        animator.SetBool("Death", death);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distStop);
        Gizmos.DrawWireSphere(transform.position, distBack);
        Gizmos.DrawWireSphere(transform.position, distAttack);
    }

    void LogicaExp()
    {
        float maxexp = exp.maxExp;
        float maxExpCont = maxexp / 2;
        float newExp = Random.Range(0, maxExpCont);
        exp.exp += newExp;
    }
}
