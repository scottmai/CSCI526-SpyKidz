using System;
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
    private CapsuleCollider2D capsuleCollider2D;

    public int health = 1;
    public Transform spawnPoint;

    public float maxSpeed = 5f;
    public bool isDead;
    private InputController player1Input;
    private InputController player2Input;
    public AudioClip CoinSound;
    public AudioClip JumpSound;
    public AudioSource audiosrc;

    void Start()
    {
        player1Input = new InputController(1);
        player2Input = new InputController(2);
        body = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        isDead = false;
        audiosrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (controlEnabled)
        {
            if (name == "Player1")
            {
                move.x = player1Input.getHorizontalAxis();
                if (IsGrounded() && player1Input.getJumpButtonDown())
                {
                    jump = true;
                }
                else if (player1Input.getJumpButtonUp())
                {
                    stopJump = true;
                    jump = false;
                }

                if (IsGrounded())
                {
                    stopJump = false;
                }

                if (player1Input.getDown())
                {
                    body.bodyType = RigidbodyType2D.Static;
                }

                if (player1Input.getUp())
                {
                    body.bodyType = RigidbodyType2D.Dynamic;
                }
            }
            else
            {
                move.x = player2Input.getHorizontalAxis();
                if (IsGrounded() && player2Input.getJumpButtonDown())
                {
                    jump = true;
                }
                else if (player2Input.getJumpButtonUp())
                {
                    stopJump = true;
                    jump = false;
                }

                if (IsGrounded())
                {
                    stopJump = false;
                }

                if (player2Input.getDown())
                {
                    body.bodyType = RigidbodyType2D.Static;
                }

                if (player2Input.getUp())
                {
                    body.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
    }

    protected void FixedUpdate()
    {
        // max velocity 5
        // 0.1 per frame is a little slow
        // 0.35 to 0.05
        float scaleFactor = 0.4f;
        body.AddForce(scaleFactor * move, ForceMode2D.Impulse);

        //if (Mathf.Abs(body.velocity.x) < maxSpeed)
        //{
        //    float scaleFactor = 0.1f;
        //    body.AddForce(scaleFactor * move, ForceMode2D.Impulse);
        //}

        //if ((posDirection && (body.velocity.x < velocityLimit))
        //    || (!posDirection && (body.velocity.x > velocityLimit)))
        //{
        //    // need to consider only velocity due to player movement forces
        //    // if player is pulled that should affect this separately

        //    float speedDiff = velocityLimit - body.velocity.x;
        //    float scaleFactor = 10f * body.mass;
        //    body.AddForce(new Vector2(scaleFactor * speedDiff * Mathf.Abs(move.x), 0), ForceMode2D.Impulse);
        //}

        //if (Mathf.Abs(move.x) - Mathf.Abs(previousHorizontal) < 0)
        //{
        //    float speedDiff = -body.velocity.x;
        //    float moveDiff = 1 - Mathf.Abs(move.x);
        //    float scaleFactor = 0.5f * body.mass;
        //    body.AddForce(new Vector2(scaleFactor * speedDiff * moveDiff, 0), ForceMode2D.Impulse);
        //}

        if (jump && !stopJump)
        {
            body.AddForce(6f * body.mass * transform.up, ForceMode2D.Impulse);
            audiosrc.clip = JumpSound;
            audiosrc.Play();
            jump = false;
        }

        previousHorizontal = move.x;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Coin")
        {
            audiosrc.clip = CoinSound;
            audiosrc.Play();
        }
    }


    private bool IsGrounded()
    {
        float extraHeight = 0.2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider2D.bounds.center, capsuleCollider2D.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
        return raycastHit.collider != null;
    }

    public void Teleport(Vector3 position)
    {
        body.position = position;
        body.velocity *= 0;
    }
    public void ResetIsDead()
    {
        isDead = false;
    }
    public bool CheckIsDead()
    {
        return isDead;
    }
}
