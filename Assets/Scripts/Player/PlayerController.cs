using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadMov;
    public bool algunTomado = false;
    public float daño;

    public int typeGun;
    public float velocidadNormal;

    [SerializeField] Transform target;
    [SerializeField] Camera cam;
    Rigidbody2D rb;
    Vector2 moveInput;
    bool FacingRight = true;
    public Animator myAnim;
    [SerializeField] Animator animArma;
    [SerializeField] ControladorCanvas ctCn;
    [SerializeField] Transform posGun;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        posGun = transform.GetChild(0);
        if(target == null)
            target = transform;
        if(cam == null)
            cam = Camera.main;

    }

    void Update()
    {
        if (ctCn.lvTerminada == false)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            moveInput = new Vector2(moveX, moveY).normalized;

            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            if (mousePos.x < transform.position.x && FacingRight)
            {
                Flip();
            }
            else if (mousePos.x > transform.position.x && !FacingRight)
            {
                Flip();
            }

            if (algunTomado == true)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    AttackWeapon(typeGun);
                }
            }

        }
        else if (ctCn.lvTerminada == true) 
        {
            velocidadMov = 0;
        }
    }
    void Flip()
    {
        Vector3 tmpScale = transform.localScale;
        tmpScale.x = -tmpScale.x;
        transform.localScale = tmpScale;
        FacingRight = !FacingRight;
        if (algunTomado) 
        {
            posGun.GetChild(0).GetComponent<Gun>().Flip();
        }
    }

    public void AttackWeapon(int type) 
    {
        type = typeGun;
        if (type == 1) 
        {
            animArma.SetTrigger("Attack");
        }
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * velocidadMov * Time.deltaTime);
        myAnim.SetBool("Idle", moveInput == Vector2.zero);
    }
}
