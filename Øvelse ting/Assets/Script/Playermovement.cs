using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float Run_speed;
    [SerializeField] private float Jump_speed;

    private float direction; //left(-1) or right(+1)

    private enum MovementState { idle, running, jumping, falling}

    [SerializeField] private AudioSource SetLandingTrigger;

    private bool facingRight = true;

    //int nummer;
    //float kommatal;
    //string text;

    //Denne metode kaldes netop en gang ..ved opstart
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>(); 

    }

    public void Update()
    {
        direction = Input.GetAxisRaw("Horizontal"); //Left = +1, Right = -1

        rb.velocity = new Vector2(direction * Run_speed, rb.velocity.y);

        //Hvis Jump (space) er installeret så ædre rigidBody y.velocity.. 
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, Jump_speed);
            

        }

        


        // går mod høre
        if (direction > 0 && facingRight == false)
        {
            FlipSprite();

        }
        // går mod venstre
        if (direction < 0 && facingRight == true)
        {
            FlipSprite();

        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState State;

        if (direction > 0f)
        {
            State = MovementState.running;
        }
        else if (direction < 0f)
        {
            State = MovementState.running;
        }
        else
        {
            State = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            State = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            State = MovementState.falling;
        }


        anim.SetInteger("State", (int)State);
    }


    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        
    }



    private void FlipSprite()
    {
        Vector3 current = gameObject.transform.localScale;
        current.x = current.x * -1;

        gameObject.transform.localScale = current;
        facingRight = !facingRight;

    }

}