using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForceController : MonoBehaviour
{
    //public bool IsGrounded { get; private set; }
    //public JumpState jumpState = JumpState.Grounded;
    private bool stopJump = false;
    bool jump = false;

    Vector2 move;
    public bool controlEnabled = true;
    private Rigidbody2D rb;

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (controlEnabled)
        {
            if (name == "Player1")
            {
                move.x = Input.GetAxis("Horizontal");
                if (Input.GetButtonDown("Jump"))
                {
                    jump = true;
                }
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    jump = false;
                }


                if (rb.velocity.y > jumpTakeOffSpeed)
                {
                    stopJump = true;
                }

                if (rb.velocity.y < 0.1)
                {
                    stopJump = false;
                }
            }
            else
            {
                move.x = Input.GetAxis("HorizontalAlternate");
                if (Input.GetButtonDown("JumpAlternate"))
                {
                    jump = true;
                }
                else if (Input.GetButtonUp("JumpAlternate"))
                {
                    stopJump = true;
                    jump = false;
                }


                if (rb.velocity.y > jumpTakeOffSpeed)
                {
                    stopJump = true;
                }

                if (rb.velocity.y < 0.1)
                {
                    stopJump = false;
                }
            }
        }
    }

    protected void FixedUpdate()
    {
        if (move.x * rb.velocity.x < maxSpeed)
        {
            rb.AddForce(0.5f * move, ForceMode2D.Impulse);
        }
    
        if (jump && !stopJump)
        {
            rb.AddForce(transform.up, ForceMode2D.Impulse);
        }
    }
}
