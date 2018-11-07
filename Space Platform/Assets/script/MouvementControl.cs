using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementControl : MonoBehaviour
{

    public float speed = 300f;
    public float jumpforce = 700f;
    private float MoveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;            //ground check variable
    public Transform groundCheck;
    private float checkRadius = 0.1f;
    public LayerMask whatIsGround;

    private int ExtraJumps;
    public int ExtraJumpsValue = 0;
    private bool jump = false;
    public Animator anim;
    private bool isMoving;


    void Start()
    {
        ExtraJumps = ExtraJumpsValue - 1;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);  //verifie si il est sur le sol

        rb.velocity = new Vector2(MoveInput, rb.velocity.y);

        if(jump == true)
        {
            rb.velocity = Vector2.up * jumpforce * Time.deltaTime;
            jump = false;
        }
    }

    void Update()
    {
        MoveInput = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        if(facingRight == false && MoveInput > 0)
        {
            flip();
        }
        else if(facingRight == true && MoveInput < 0)
        {
            flip();
        }

        if(isGrounded == true)
        {
            ExtraJumps = ExtraJumpsValue - 1;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && ExtraJumps >= 0)
        {
            ExtraJumps--;
            jump = true;
        }

        if(MoveInput > 0 || MoveInput < 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        anim.SetBool("moving", isMoving);
    }

    void flip() //retourne le sprite du perso de 180 degrer
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
