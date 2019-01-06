using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightStatus : MonoBehaviour
{
    //master bool to determine if player is in the light
    public bool inTheLight;

    //used for game over and reset
    public Transform spawnPoint;
    public GameObject gameOverPanel;

    void Awake ()
    {
        inTheLight = true;
        gameOverPanel.SetActive(false);
    }

    //if player leaves the light, play game over sequence
    void Update()
    {
        if (inTheLight == false)
        {
            GameOverSequence();
        }
    }

    //everything that happens when the player dies
    void GameOverSequence()
    {
        //game over message plays
        //gameOverPanel.SetActive(true);

        //press e to restart
        if (Input.GetKeyDown("e"))
        {
            this.transform.position = spawnPoint.position;
            this.transform.rotation = spawnPoint.rotation;
            gameOverPanel.SetActive(false);
        }
    }
}
