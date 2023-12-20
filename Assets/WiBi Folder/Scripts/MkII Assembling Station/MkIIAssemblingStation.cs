using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This script was created by Liam Wilson
// For the purpose of the MkII Assembling station mechanics

// !!! THIS SCRIPT IS NO LONGER USED !!!
// We use MkI instead as it was better, for us.

public class MkIIAssemblingStation : MonoBehaviour
{
    [Header("GameObjects & References")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject toyAssembler;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject playerCam;

    [Header("Bools & Numbers")]
    [SerializeField] float dist;
    [SerializeField] int toySelected;
    [SerializeField] bool playerHasTheMaterials;

    // Start is called before the first frame update
    void Start()
    {
        // Collects player gameObject.
        player = GameObject.FindGameObjectWithTag("Player");
        // Sets canvas inactive
        canvas.SetActive(false);
        // Sets camera inactive
        cam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Constantly updates the distance between this object and the player.
        dist = Vector3.Distance(transform.position, player.transform.position);
        // Checks whether the player is within range
        if (dist <= 3)
        {
            // Sets the canvas to be active
            canvas.SetActive(true);
            // Checks if the player has the correct materials, and has pressed E
            if (playerHasTheMaterials && Input.GetKeyDown(KeyCode.E))
            {
                // Code to allow for assembly
                //toyAssembler.GetComponent<ToyAssembly>().assemble = true;
                // Cam to be set active
                cam.SetActive(true);
                // Player to be set inactive
                player.SetActive(false);
                // PlayerCam to be set inactive
                playerCam.SetActive(false);
            }
        }
        else
        {
            // Canvas to be set inactive, if player is further than suggested.
            canvas.SetActive(false);
        }
    }

}
