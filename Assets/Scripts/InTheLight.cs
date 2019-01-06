using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InTheLight : MonoBehaviour
{
    public bool inTheLight;

    public Transform spawnPoint;
    public GameObject gameOverPanel;

    //make sure game over message is off at start
    void Awake ()
    {
        gameOverPanel.SetActive(false);
    }

    //knows ever frame that player is within the light collider
    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "light")
        {
            inTheLight = true;
        }
    }

    //triggers when player leaves the light
    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "light")
        {
            inTheLight = false;
        }
    }

    void Update()
    {
        //Debug.Log(inTheLight);

        //if player leaves the light, play game over sequence
        if (inTheLight == false)
        {
            GameOverSequence();
        }
    }

    //everything that happens when the player dies
    void GameOverSequence ()
    {
        gameOverPanel.SetActive(true);

        if (Input.GetKeyDown ("e"))
        {
            this.transform.position = spawnPoint.position;
            this.transform.rotation = spawnPoint.rotation;
            gameOverPanel.SetActive(false);
        }
    }
}
