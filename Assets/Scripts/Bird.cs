using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isDead = false;
    public static Rigidbody2D rb;
    public static Animator anim;
    public float upForce = 100f;
    public float downForce = -200f;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update ()
    {
		if( !isDead )
        {
            if( Input.GetKeyDown(KeyCode.Space) )
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
            
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = Vector2.zero;
            isDead = true;
            GameController.instance.birdDied();
        }
    }
}
