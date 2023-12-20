using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was created by Liam Wilson,
// For the purpose of collecting data and sending it around.

public class BlueprintClicker : MonoBehaviour
{
    [Header("Camera / Layer / Bool")]
    [SerializeField] GameObject cam;
    [SerializeField] GameObject toyAssembler;
    [SerializeField] LayerMask blueprint;
    public bool alreadyGotBlueprint;
    // Start is called before the first frame update
    void Start()
    {
        // Code to collect the player's camera object
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        // Hit referance for collecting data based on what the raycast has hit.
        RaycastHit hit;
        // If statement for raycast, sending it forward of the cam, and out
        // putting something to the hit var, if the object hit is on the blueprint layer
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, blueprint))
        {
            // Code to draw the raycast for debugging purposes. 
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            // If statement for registering the LMB click, if raycast hit returns true first.
            if (Input.GetButtonDown("Fire"))
            {
                // If statment to check if the hit object has a collider
                if (hit.collider != null)
                {
                    // If statement to check if a blueprint hasn't already been assigned.
                    if (!alreadyGotBlueprint)
                    {
                        // Code to collect the blueprint id from the hit object.
                        int b = hit.collider.gameObject.GetComponent<BlueprintID>().id;
                        // Code to call the blueprint function within the blueprint giver script.
                        gameObject.GetComponent<BlueprintGiver>().Blueprints(b);
                        // Sends toy id to the toy assembler
                        toyAssembler.GetComponent<ToyAssembly>().toyId = b;
                        // Sets the bool to be true, to prevent the code from happening again
                        // until the toy is done
                        alreadyGotBlueprint = true;
                    }
                    
                }
            }
        }
    }
}
