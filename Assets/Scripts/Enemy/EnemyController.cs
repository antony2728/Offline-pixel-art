using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public int velocidad;
    public float esperar;
    public float velocidaddereversa;
    public float distanciadejugador;
    public float rangodevision;
    public float rangodereversa;
    public float rangodedisparo;
    public float vida;

    PlayerController cont;
    Transform Player;
    public Rigidbody2D rb2d;
    private float latestDirectionChangeTime;
    private readonly float
    //estas 2 con numero float sirven para la velocidad random del enemigo
    directionChangeTime = 1f;
    private float characterVelocity = 5f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    GameObject target;
    ExpPlayer exp;
    ControladorPartida contPart;

    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
        target = GameObject.FindGameObjectWithTag("Player");
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        exp = GameObject.FindGameObjectWithTag("Player").GetComponent<ExpPlayer>();
        contPart = GameObject.FindGameObjectWithTag("Controlador").GetComponent<ControladorPartida>();
    }
    void calcuateNewMovementVector()
    {
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }
    private void Update()
    {
        //condicion de asercamiento ese 4 mientras mas grande sea mas lejos se detendra y empezara a buscar antes
        if (Vector3.Distance(transform.position, target.transform.position) < rangodevision)
        {
            //persigue al jugador se puede configurar en unity gracias a que es publico
            distanciadejugador = Vector2.Distance(Player.position, rb2d.position);
            if (distanciadejugador < rangodevision && distanciadejugador > rangodereversa && distanciadejugador > rangodedisparo)
            {
                Vector2 objetivo = new Vector2(Player.position.x, Player.position.y);
                Vector2 nuevopos = Vector2.MoveTowards(rb2d.position, objetivo, velocidad * Time.deltaTime);
                rb2d.MovePosition(nuevopos);
            }
            else if (distanciadejugador < rangodevision && distanciadejugador > rangodereversa && distanciadejugador <= rangodedisparo)
            {
                Vector2 objetivo = new Vector2(Player.position.x, Player.position.y);
                Vector2 nuevopos = Vector2.MoveTowards(rb2d.position, objetivo, 0 * Time.deltaTime);
                rb2d.MovePosition(nuevopos);
            }
            else if (distanciadejugador < rangodereversa)
            {
                Vector2 objetivo = new Vector2(Player.position.x, Player.position.y);
                Vector2 nuevopos = Vector2.MoveTowards(rb2d.position, objetivo, velocidaddereversa * Time.deltaTime);
                rb2d.MovePosition(nuevopos);
            }
        }
        else
        {
            // el modo de camniar random por el mapa si quieren cambiarlo lo que deben cambiar es el numero directionChangeTime = 1f;
            if (Time.time - latestDirectionChangeTime > directionChangeTime)
            {
                latestDirectionChangeTime = Time.time;
                calcuateNewMovementVector();
            }
            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangodevision);
        Gizmos.DrawWireSphere(transform.position, rangodedisparo);
        Gizmos.DrawWireSphere(transform.position, rangodereversa);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PosArma"))
        {
            vida -= cont.daño;
            if (vida <= 0) 
            {
                Destroy(gameObject);
            }
        }
    }


    void LogicaExp() 
    {
        float maxexp = exp.maxExp;
        float maxExpCont = maxexp / 2;
        float newExp = Random.Range(0, maxExpCont);
        exp.exp += newExp;
    }
}

