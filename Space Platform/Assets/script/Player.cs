using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 300f;
    public float jumpforce = 700f;
    public int ExtraJumpsValue = 0;
    public float DashForce = 300f;
    public float PVMax = 100;
    public float PushBackX = 1000f;
    public float PushBackY = 1000f;
    private float MoveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;            //ground check variable
    public Transform groundCheck;
    private float checkRadius = 0.1f;
    public LayerMask whatIsGround;

    private int ExtraJumps;
    private bool jump = false;
    public Animator anim;
    private bool isMoving;

    bool dash = false;
    private float DashSpeed;

    public PlayerHealthBar Health;

    private float PV;
    private bool PushBack = false;


    void Start()
    {
        ExtraJumps = ExtraJumpsValue - 1;
        rb = GetComponent<Rigidbody2D>();
        PV = PVMax;
    }

    void FixedUpdate()
    {
        //verifie si il est sur le sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        rb.velocity = new Vector2(MoveInput * speed * Time.deltaTime, rb.velocity.y);

        if (jump == true)
        {
            rb.velocity = Vector2.up * jumpforce * Time.deltaTime;
            jump = false;
        }

        if (dash == true)
        {
            rb.velocity = new Vector2(DashSpeed, rb.velocity.y);
            dash = false;
        }

        if ((PushBack == true) && (facingRight == true))
        {
            rb.velocity = new Vector2(-PushBackX, PushBackY);
            PushBack = false;
        }
        else if ((PushBack == true) && (facingRight == false))
        {
            rb.velocity = new Vector2(PushBackX, PushBackY);
            PushBack = false;
        }
    }

    void Update()
    {
        //remplissage de la bar de vie
        Health.fill(PV, PVMax);


        //deplacement
        MoveInput = Input.GetAxisRaw("Horizontal");
        if (facingRight == false && MoveInput > 0)
        {
            flip();
        }
        else if (facingRight == true && MoveInput < 0)
        {
            flip();
        }


        //Compteur de saut
        if (isGrounded == true)
        {
            ExtraJumps = ExtraJumpsValue - 1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && ExtraJumps >= 0)
        {
            ExtraJumps--;
            jump = true;
        }


        //dash
        if (Input.GetKeyDown(KeyCode.F))
        {
            DashSpeed = DashForce * Time.deltaTime * MoveInput;
            dash = true;
        }


        //animator
        if (MoveInput > 0 || MoveInput < 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        anim.SetBool("moving", isMoving);
    }


    //retourne le sprite du perso de 180 degrer
    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


    //execution des dega
    public void gotHit(float damage)
    {
        PV -= damage;
        PushBack = true;
    }
}
