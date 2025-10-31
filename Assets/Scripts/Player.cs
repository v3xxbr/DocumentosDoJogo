using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Componnents")]
    SpriteRenderer spr;
    Rigidbody2D rb;
    Animator anim;

    [Header("Attributes")]
    public static float speed = 3.5f;
    float jumpForce = 4f;

    [Header("StagesVars")]
    bool isJumping;

    public Vector2 moveInput;

    [Header("Foot")]
    [SerializeField]private Transform foot;
    [SerializeField]private float footRadius=0.2f;
    [SerializeField]private LayerMask ground;

    public enum stages{
        Idle,
        Running,
        Jumping,
        Dead
    }

    public static stages currentStage;

    // Start is called before the first frame update
    void Start()
    {
        currentStage = stages.Idle;

        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * speed, rb.velocity.y);
        Animations();
    }

    public void Update()
    {
        isJumping = !Physics2D.OverlapCircle(foot.position, footRadius, ground);
    }

    public void Move(InputAction.CallbackContext value)
    {
        moveInput = value.ReadValue<Vector2>();
        currentStage = stages.Running;
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (value.started && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            currentStage = stages.Jumping;
            isJumping = true;
        }
    }

    private void Animations()
    {
        if (isJumping)
          anim.SetInteger("transition", 2);

        else if (moveInput.x != 0)
          anim.SetInteger("transition", 1);

        else
          anim.SetInteger("transition", 0);
        

        flipSprite();
    }

    public void Dead()
    {
        gameObject.SetActive(false);
        ++deathCount.deathTimes;
        deathCount.itsover = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Hit") || other.gameObject.CompareTag("Hit"))
        {
            Dead();
        }
    }

    private void OnDrawGizmos()
    {
        if(foot != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(foot.position, footRadius);
        }   
    }

    private void flipSprite()
    {
        //caso o personagem ande para a esquerda
        if (moveInput.x<0)
            spr.flipX = true;

        //caso ande para a direita
        else if(moveInput.x>0)
            spr.flipX = false;
    }
}
