using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Animator animator;
    public float speed = 5.0f;
    public float jumpForce = 7.0f;
    private bool isGrounded = true;
    private Rigidbody2D rb;
    private Vector3 direita;
    private Vector3 esquerda;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direita = transform.localScale;
        esquerda = transform.localScale;
        esquerda.x = esquerda.x * -1;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * speed;

        if (horizontal > 0)
        {
            transform.localScale = direita;
        }
        if (horizontal < 0)
        {
            transform.localScale = esquerda;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("Jump", true);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jump", false);
            isGrounded = true;
        }
    }
}