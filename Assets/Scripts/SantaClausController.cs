using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaClausController : MonoBehaviour
{
    // public properties
    public float velocityX = 5;

    // private properties
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;
    
    // constants
    private const int ANIMATION_IDLE = 0;
    private const int ANIMATION_RUN = 1;
    
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
            rb.velocity = Vector2.right * velocityX;
            sr.flipX = false;
            changeAnimation(ANIMATION_RUN);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.right * -velocityX;
            sr.flipX = true;
            changeAnimation(ANIMATION_RUN);
        }
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
