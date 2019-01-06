using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HingeConnect : MonoBehaviour
{
    private HingeJoint connectHinge;


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "lantern" && Input.GetKey(KeyCode.E))
        {
            connectHinge = gameObject.GetComponent<HingeJoint>();
            connectHinge.connectedBody = other.GetComponent<Rigidbody>();

        }

    }
}
