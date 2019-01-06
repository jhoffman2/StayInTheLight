using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInLight : MonoBehaviour
{
    public LightStatus lightStatusScript;
    private GameObject playerTarget;
    private float sphereRadius;

    void Awake ()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        sphereRadius = GetComponent<SphereCollider>().radius;
    }

    void OnTriggerStay (Collider other)
    {
        if (other.gameObject == playerTarget)
        {
            Vector3 direction = playerTarget.transform.position - transform.position;

            RaycastHit hit;

            if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, sphereRadius*10))
            {
                if (hit.collider.gameObject == playerTarget)
                {
                    //Debug.Log("player is in the light");
                    lightStatusScript.inTheLight = true;
                }
                if (hit.collider.gameObject.tag == "obstacle")
                {
                    //Debug.Log("player is in a shadow");
                    lightStatusScript.inTheLight = false;
                }
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject == playerTarget)
        {
            //Debug.Log ("player has left the light");
            lightStatusScript.inTheLight = false;
        }
    }
}
