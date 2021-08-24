using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaClausController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(10, 0);
            animator.SetInteger("Estado", 1);
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetInteger("Estado", 0);
        }
    }
}
