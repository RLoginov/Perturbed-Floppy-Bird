using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{

    public static Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("GameStart");
    }

    void Update ()
    {
        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            StartCoroutine(MyCoroutine());
        }
	}

    IEnumerator MyCoroutine()
    {
        anim.SetTrigger("Launched");
        yield return new WaitForSeconds(1);
        GameController.instance.birdLaunched = true;
    }
}
