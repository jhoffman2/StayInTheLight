using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class InteractionControl : MonoBehaviour
{
    public InteractionSystem interactionSystem;
    

    void OnGUI()
    {
        int closestTriggerIndex = interactionSystem.GetClosestTriggerIndex();

        if (closestTriggerIndex == -1) return;

        GUILayout.Label("In range");

       
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactionSystem.TriggerInteraction(closestTriggerIndex, false);
                
            }

           
       
    }
}
