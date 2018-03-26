using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverText;
    public AudioClip gameOverSound;
    public GameObject bird;
    public bool gameOver;
    public bool birdLaunched;
    public float scrollSpeed = -2f;

	void Awake ()
    {
        gameOver = false;
        birdLaunched = false;
        bird.SetActive(false);

		if( instance == null )
            instance = this;

        else if( instance != this )
            Destroy(gameObject);

        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = gameOverSound;
    }


	
	void Update ()
    {
        if( birdLaunched )
            bird.SetActive(true);

        if ( gameOver && Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Start Menu");
    }

    public void birdDied()
    {
        Bird.anim.SetTrigger("Dead");
        gameOver = true;
        gameOverText.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
}
