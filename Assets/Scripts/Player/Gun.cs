using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public int type;
    //Amelee --- 1
    //Distance - 2

    //Distance Var
    Transform myTrans;
    public int speedBullet;

    public GameObject bulletPrefab;

    SpriteRenderer mySprite;
    Vector3 target;
    Vector3 finalTarget;
    [SerializeField] Transform pointFire;
    //

    [SerializeField] int numGun;
    Equipamento equip;
    Transform posArma;
    public bool take = false;
    PlayerController playerController;
    public float dañoAsignar;
    private void Start()
    {
        posArma = GameObject.FindGameObjectWithTag("PosArma").GetComponent<Transform>();
        mySprite = GetComponent<SpriteRenderer>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        equip = GameObject.FindGameObjectWithTag("Player").GetComponent<Equipamento>();
    }

    void Update()
    {
        if (take == true) 
        {
            if (Input.GetKey(KeyCode.Q)) 
            {
                transform.SetParent(null);
                transform.rotation = Quaternion.identity;
                playerController.typeGun = 0;
                take = false;
                PlayerPrefs.SetInt("Gun", 0);
                playerController.algunTomado = false;
            }

            if (type == 2) 
            {
                target = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                var angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                if (angle > 90 || angle < -90)
                    mySprite.flipY = true;
                else
                    mySprite.flipY = false;

                if (Input.GetMouseButtonDown(1)) 
                {
                    Shoot();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if (Input.GetKey(KeyCode.E) && take == false) 
            {

                if (playerController.algunTomado == false) 
                {
                    transform.SetParent(posArma);
                    transform.position = posArma.position;
                    playerController.daño = dañoAsignar;
                    playerController.algunTomado = true;
                    playerController.typeGun = type;
                    equip.nameGun = numGun;
                    PlayerPrefs.SetInt("Gun", equip.nameGun);
                    take = true;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && take == false)
            {

                if (playerController.algunTomado == false)
                {
                    transform.SetParent(posArma);
                    transform.position = posArma.position;
                    playerController.daño = dañoAsignar;
                    playerController.algunTomado = true;
                    playerController.typeGun = type;
                    equip.nameGun = numGun;
                    PlayerPrefs.SetInt("Gun", equip.nameGun);
                    take = true;
                }
            }
        }
    }


    void Shoot() 
    {
        var ball = Instantiate(bulletPrefab, pointFire.position, transform.rotation);
        target.z = 0;
        finalTarget = (target - transform.position).normalized;
        ball.GetComponent<Rigidbody2D>().AddForce(finalTarget * speedBullet, ForceMode2D.Impulse);
        ball.GetComponent<Bullet>().damage = dañoAsignar;
        Destroy(ball, 3f);
    }

    public void Flip()
    {
        Vector3 tmpScale = transform.localScale;
        tmpScale.x = -tmpScale.x;
        transform.localScale = tmpScale;
    }
}
