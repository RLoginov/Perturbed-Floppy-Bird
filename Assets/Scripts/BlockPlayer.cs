using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Bird.rb.constraints = RigidbodyConstraints2D.FreezeAll;
            GameController.instance.birdDied();
        }
    }
}
