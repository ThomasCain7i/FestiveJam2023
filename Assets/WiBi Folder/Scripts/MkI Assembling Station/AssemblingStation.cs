using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was created by Liam Wilson
// For the purpose of controling the basics of the Assembly Station mechanics

public class AssemblingStation : MonoBehaviour
{
    [Header("GameObjects & References")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject toyAssembler;

    [Header("Bool & Numbers")]
    [SerializeField] float dist;
    [SerializeField] int toySelected;
    [SerializeField] bool playerHasTheMaterials;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the player gameobject, for ease of use.
        player = GameObject.FindGameObjectWithTag("Player");
        // Sets canvas object to be in active on start
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Constantly getting the distance between, this script's gameObject and the player
        dist = Vector3.Distance(transform.position, player.transform.position);
        if(dist <= 3)
        {
            // Sets canvas to be active, if player is within range
            canvas.SetActive(true);
            // Allows the player to interact if the press E and have the materials.
            if (playerHasTheMaterials && Input.GetKeyDown(KeyCode.E))
            {
                // Sets bool to be true if the player has interacted with the table.
                toyAssembler.GetComponent<ToyAssembly>().gameHasStarted = true;
            }
        }
        else
        {
            // Sets the canvas to be in active if the player is anything otehr than within range.
            canvas.SetActive(false);
        }
    }
}
