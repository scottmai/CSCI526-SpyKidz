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
    internal Animator animator;

    void Start()
    {
        player1Input = new InputController(1);
        player2Input = new InputController(2);
        body = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        isDead = false;
        audiosrc = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 charScale = transform.localScale;
        if (controlEnabled)
        {
            if (name == "Player1")
            {
                move.x = player1Input.getHorizontalAxis();
                if (move.x > 0 || move.x < 0)
                {
                    animator.ResetTrigger("run-idle");
                    if (move.x > 0)
                    {
                        charScale.x = -0.5f;
                        animator.SetTrigger("idle-run");
                    }
                    else
                    {
                        charScale.x = 0.5f;
                        animator.SetTrigger("idle-run");
                    }
                }
                else
                {
                    animator.ResetTrigger("idle-run");
                    animator.SetTrigger("run-idle");
                }

                if ((move.x > 0 || move.x < 0) && IsGrounded() && player1Input.getJumpButtonDown())
                    animator.SetTrigger("run-jump");

                if (IsGrounded() && player1Input.getJumpButtonDown())
                {
                    jump = true;
                    animator.SetTrigger("idle-jump");
                }
                else if (player1Input.getJumpButtonUp())
                {
                    stopJump = true;
                    jump = false;
                    animator.ResetTrigger("idle-jump");
                    animator.SetTrigger("jump-idle");
                    animator.ResetTrigger("run-jump");
                }

                if (IsGrounded())
                {
                    stopJump = false;
                }

                if ((player1Input.getDown() && IsGrounded()) || (player1Input.getDown() && !IsGrounded()))
                {
                    body.bodyType = RigidbodyType2D.Static;
                    animator.ResetTrigger("jump-idle");
                    animator.ResetTrigger("duck-idle");
                    animator.SetTrigger("idle-duck");
                }

                if (player1Input.getUp())
                {
                    body.bodyType = RigidbodyType2D.Dynamic;
                    animator.ResetTrigger("idle-duck");
                    animator.SetTrigger("duck-idle");
                }
            }
            else
            {
                move.x = player2Input.getHorizontalAxis();
                if (move.x > 0 || move.x < 0) {
                    animator.ResetTrigger("run-idle");
                    if (move.x > 0)
                    {
                        charScale.x = -0.5f;
                        animator.SetTrigger("idle-run");
                    }
                    else
                    {
                        charScale.x = 0.5f;
                        animator.SetTrigger("idle-run");
                    }
                }         
                else
                {
                    animator.ResetTrigger("idle-run");
                    animator.SetTrigger("run-idle");
                }

                if ((move.x > 0 || move.x < 0) && IsGrounded() && player2Input.getJumpButtonDown())
                    animator.SetTrigger("run-jump");

                if (IsGrounded() && player2Input.getJumpButtonDown())
                {
                    jump = true;
                    animator.SetTrigger("idle-jump");
                }
                else if (player2Input.getJumpButtonUp())
                {
                    stopJump = true;
                    jump = false;
                    animator.ResetTrigger("idle-jump");
                    animator.SetTrigger("jump-idle");
                    animator.ResetTrigger("run-jump");
                }

                if (IsGrounded())
                {
                    stopJump = false;
                }

                if ((player2Input.getDown() && IsGrounded()) || (player2Input.getDown() && !IsGrounded()))
                {
                    body.bodyType = RigidbodyType2D.Static;
                    animator.ResetTrigger("jump-idle");
                    animator.ResetTrigger("duck-idle");
                    animator.SetTrigger("idle-duck");

                }

                if (player2Input.getUp())
                {
                    body.bodyType = RigidbodyType2D.Dynamic;
                    animator.ResetTrigger("idle-duck");
                    animator.SetTrigger("duck-idle");
                }
            }
        }
        transform.localScale = charScale;
    }

    protected void FixedUpdate()
    {
        
        float scaleFactor = 0.4f;
        body.AddForce(scaleFactor * move, ForceMode2D.Impulse);

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
