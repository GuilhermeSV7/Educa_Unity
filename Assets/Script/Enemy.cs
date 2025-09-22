using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variaveis
    public float speed;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public int direction = 1;

    private void Start()
    {
        //Acesando componenents
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Logica de mudanca de Direcao
        if (collision.collider.CompareTag("Wall"))
        {
            direction *= -1;
            sprite.flipX = (direction < 0);
        }
    }
}
