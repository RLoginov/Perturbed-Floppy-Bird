using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float knockback = 2000f;
    public GameObject projectile;
    public Transform shotSpawn;
    public float fireRate = 3f;
    private float nextFire = 0.0F;
    private bool active;
    public AudioClip shutdown;

    private void Awake()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = shutdown;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        active = true;
    }

    void Update()
    {
        if (Time.time > nextFire && !GameController.instance.gameOver && active )
        {
            nextFire = Time.time + fireRate;
            Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            if( active )
                GetComponent<AudioSource>().Play();

            active = false;
            rb.AddForce(new Vector2(knockback, 0f));        }
    }
}
