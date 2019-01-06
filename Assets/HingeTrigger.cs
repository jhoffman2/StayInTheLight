using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeTrigger : MonoBehaviour
{
    private FixedJoint connectHinge;
    private Rigidbody rb;
    public bool lanternPickedUp;


    private void Start()
    {
        lanternPickedUp = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lantern")
        {
           // if (Input.GetKeyDown(KeyCode.E))
           // {
               
               if (lanternPickedUp == false)
                {
                    other.transform.parent = transform;
                    
                    rb.isKinematic = true;
                    var handLocation = GetComponent<Transform>().transform.position;
                    other.transform.position = handLocation;
                    lanternPickedUp = true;
                }
           // }
            
            

        }

    }

    private void Update()
    {
        if (lanternPickedUp == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("lantern picked is true");
           // other.transform.parent = null;
           // other.GetComponent<Rigidbody>().isKinematic = false;
            lanternPickedUp = false;
        }
    }
}
