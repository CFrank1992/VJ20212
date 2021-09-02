using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaClausController : MonoBehaviour
{
    // public properties
    public float velocityX = 15;
    public float jumpForce = 40;

    // private components
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;
    
    
    // private properties
    private bool isIntangible = false;
    private float intangibleTime = 0f;
    
    // constants
    private const int ANIMATION_IDLE = 0;
    private const int ANIMATION_RUN = 1;
    private const int ANIMATION_SLIDE= 2;
    private const int ANIMATION_JUMP= 3;

    private const int LAYER_GROUND = 10;

    private const string TAG_ENEMY = "Enemy";
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Iniciando Game Object");
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(ANIMATION_IDLE); 
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y); 
            sr.flipX = false;
            changeAnimation(ANIMATION_RUN);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(ANIMATION_RUN);
        }
        
        if (Input.GetKey(KeyCode.X))
        {
            changeAnimation(ANIMATION_SLIDE);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // salta
            changeAnimation(ANIMATION_JUMP); // saltar
        }

        if (isIntangible && intangibleTime < 2f)
        {
            intangibleTime += Time.deltaTime;
            sr.enabled = !sr.enabled;
        }
        else if(isIntangible && intangibleTime >= 2f)
        {
            isIntangible = false;
            sr.enabled = true;
            intangibleTime = 0f;
            // Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LAYER_GROUND && collision.gameObject.tag == "Ground")
        {
            Debug.Log("Collision: " + collision.gameObject.name);
        }

        if (collision.gameObject.CompareTag(TAG_ENEMY))
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1);
            isIntangible = true;
            // Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), true);
        }

        if (collision.gameObject.name == "Vida")
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 1);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
       Debug.Log("Trigger:" + this.name);
    }


    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
