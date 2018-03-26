using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMusic : MonoBehaviour
{
    public AudioClip gameMusic;

    void Awake ()
    {
        GetComponent<AudioSource>().playOnAwake = true;
        GetComponent<AudioSource>().clip = gameMusic;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if( GameController.instance.gameOver )
            GetComponent<AudioSource>().Stop();
    }
}
