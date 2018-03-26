using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velX = -5f;
    public float velY = 0f;
    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bird.rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GameController.instance.birdDied();
            Destroy(gameObject);
        }
    }
}
