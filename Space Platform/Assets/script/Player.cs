using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 500f;
    public float jumpforce = 700f;
    public float DashSpeed;
    public float StartDashTime;
    public float DashStamina = 10f;
    public float PVMax = 100f;
    public float AnduranceMax = 100f;
    private float MoveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    private bool isGroundedPrev;
    public Transform groundCheck;
    private float checkRadius = 0.5f;
    public LayerMask whatIsGround;

    private int ExtraJumps;
    private bool jump = false;
    public Animator anim;
    private bool isMoving;

    bool dash = false;
    private float DashTime;

    public PlayerHealthBar Health;
    public Stamina Andu;

    private float PV;
    private float Andurance;


    void Start()
    {
        ExtraJumps = 1;
        rb = GetComponent<Rigidbody2D>();
        PV = PVMax;
        Andurance = AnduranceMax;
        DashTime = StartDashTime;
        isGroundedPrev = isGrounded;
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


        //Dash
        if (DashTime > 0 && dash == true)
        {
            DashTime -= Time.deltaTime;

            if (dash == true && MoveInput > 0)
            {
                rb.velocity = Vector2.right * DashSpeed;
            }
            else if (dash == true && MoveInput < 0)
            {
                rb.velocity = Vector2.left * DashSpeed;
            }
        }
    }

    void Update()
    {
        //remplissage des bares
        Health.fill(PV, PVMax);
        Andu.fill(Andurance, AnduranceMax);

        if(Andurance <= AnduranceMax)
        {
            Andurance = Andurance + (5 * Time.deltaTime);
        }


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
        if (isGrounded == true && isGroundedPrev == false)
        {
            ExtraJumps = 1;
        }
        isGroundedPrev = isGrounded;
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && ExtraJumps >= 0)
        {
            ExtraJumps--;
            jump = true;
        }


        //dash
        if ((Input.GetKeyDown(KeyCode.F)) && (Andurance >= DashStamina))
        {
            Andurance = Andurance - DashStamina;
            dash = true;
        }
        if (DashTime <= 0)
        {
            dash = false;
            DashTime = StartDashTime;
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
        anim.SetBool("jump", !isGrounded);


        //Player Die
        if (PV <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
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
    }
}
