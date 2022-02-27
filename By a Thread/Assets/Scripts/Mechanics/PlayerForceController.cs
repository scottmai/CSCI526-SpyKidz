using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForceController : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    //public JumpState jumpState = JumpState.Grounded;
    private bool stopJump = false;
    bool jump = false;

    Vector2 move;
    float previousHorizontal = 0;
    public bool controlEnabled = true;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider2D;

    public int health = 1;
    public Transform spawnPoint;

    public float maxSpeed = 0.8f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (controlEnabled)
        {
            if (name == "Player1")
            {
                move.x = Input.GetAxis("Horizontal");
                if (IsGrounded() && Input.GetButtonDown("Jump"))
                {
                    jump = true;
                }
                else if (Input.GetButtonUp("Jump"))
                {
                    stopJump = true;
                    jump = false;
                }

                if (IsGrounded())
                {
                    stopJump = false;
                }
            }
            else
            {
                move.x = Input.GetAxis("HorizontalAlternate");
                if (IsGrounded() && Input.GetButtonDown("JumpAlternate"))
                {
                    jump = true;
                }
                else if (Input.GetButtonUp("JumpAlternate"))
                {
                    stopJump = true;
                    jump = false;
                }

                if (IsGrounded())
                {
                    stopJump = false;
                }
            }
        }
    }

    protected void FixedUpdate()
    {
        if (move.x * body.velocity.x < maxSpeed)
        {
            // need to consider only velocity due to player movement forces
            // if player is pulled that should affect this separately

            float speedDiff = maxSpeed - Mathf.Abs(body.velocity.x);
            float scaleFactor = 2f * body.mass;
            body.AddForce(scaleFactor * move, ForceMode2D.Impulse);
        }

        //if (Mathf.Abs(move.x) - Mathf.Abs(previousHorizontal) < 0)
        //{
        //    float speedDiff = -body.velocity.x;
        //    float moveDiff = 1 - Mathf.Abs(move.x);
        //    float scaleFactor = 0.05f * body.mass;
        //    body.AddForce(new Vector2(scaleFactor * speedDiff * moveDiff, 0), ForceMode2D.Impulse);
        //}

        if (jump && !stopJump)
        {
            body.AddForce(6f * body.mass * transform.up, ForceMode2D.Impulse);
            jump = false;
        }

        previousHorizontal = move.x;
    }


    private bool IsGrounded()
    {
        float extraHeight = 0.2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
        return raycastHit.collider != null;
    }

    public void Teleport(Vector3 position)
    {
        body.position = position;
        body.velocity *= 0;
    }
}
