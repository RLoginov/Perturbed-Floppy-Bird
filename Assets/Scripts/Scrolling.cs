using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    private Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        if (GameController.instance.birdLaunched)
            rb.velocity = new Vector2(GameController.instance.scrollSpeed, 0f);

        if ( GameController.instance.gameOver )
            rb.velocity = Vector2.zero;
	}
}
