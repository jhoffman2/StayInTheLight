using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using RootMotion.Demos;

public class HoldLantern : MonoBehaviour
{
    public InteractionObject lantern;
    public OffsetPose holdPose;

    private float holdWeight;
    private FullBodyBipedIK ik;

    public bool lanternHook;
   
    private HingeJoint connectHinge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "lantern")
        {
            connectHinge = other.GetComponent<HingeJoint>();
            lanternHook = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "lantern") lanternHook = false;
    }


    IEnumerator OnPickUp()
    {
        ik = lantern.lastUsedInteractionSystem.GetComponent<FullBodyBipedIK>();
        ik.solver.rightHandEffector.rotationWeight = 0.1f;
        while (holdWeight < 1f)
        {
            holdWeight += Time.deltaTime;
            yield return null;
        }
        Debug.Log("lantern was picked up");
    }

    private void Start()
    {
        lanternHook = false;
    }

    private void LateUpdate()
    {
        if (ik == null) return;

        holdPose.Apply(ik.solver, holdWeight, ik.transform.rotation);
        
        //ik.solver.rightHandEffector.positionOffset += ik.transform.rotation * holdOffset * holdWeight;
    }

    private void Update()
    {
        if (ik == null) return;

        if (Input.GetKeyDown(KeyCode.E)) StartCoroutine(Drop());
        
    }

    IEnumerator Drop()
    {
        if (lanternHook == true)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            connectHinge.connectedBody = GetComponent<Rigidbody>();
            ik.solver.rightHandEffector.rotationWeight = 0f;
            while (holdWeight > 0f)
            {
                holdWeight -= Time.deltaTime * 3f;
                yield return null;
            }
        }
        else
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
        ik.solver.rightHandEffector.rotationWeight = 0f;
        while (holdWeight > 0f)
        {
            holdWeight -= Time.deltaTime * 3f;
            yield return null;
        }

    }
}
