using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Atributos
    public float speed;
    public float jump;
    public bool isGrounded;
    public int vida;

    //Componentes
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    //Iniciar quando apertamos o Play
    private void Start()
    {
        rb  = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponent<SpriteRenderer>();
        anim = rb.GetComponent<Animator>();
    }

    private void Update()
    {
        Walking();
        Jump();
    }

    void Walking()
    {
        //Movimenta A e D
        float move = Input.GetAxisRaw("Horizontal");

        //Acessando os Vetores
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (move > 0) sprite.flipX = false;
        if (move < 0) sprite.flipX = true;

        anim.SetBool("IsWalking", move != 0);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
