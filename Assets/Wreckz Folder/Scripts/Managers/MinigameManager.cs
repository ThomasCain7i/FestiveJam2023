using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was created by Liam Wilson
// For the purpose of controling the basics of the Assembly Station mechanics

public class MinigameManager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject player;

    [Header("MiniGames")]
    [SerializeField] GameObject toyAssembler;
    [SerializeField] GameObject nailStation;

    [Header("Distance")]
    [SerializeField] float distanceToyAssembler;
    [SerializeField] float distanceNailStation;

    [Header("Canavs")]
    [SerializeField] GameObject canvasToyAssembler;
    [SerializeField] GameObject canvasNailStation;


    [Header("Bool & Numbers")]
    [SerializeField] int toySelected;
    [SerializeField] bool playerHasTheMaterials;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the player gameobject, for ease of use.
        player = GameObject.FindGameObjectWithTag("Player");
        // Sets canvas object to be inactive on start
        canvasNailStation.SetActive(false);
        canvasToyAssembler.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Constantly getting the distance between, the toyAssembler gameObject and the player
        distanceToyAssembler = Vector3.Distance(toyAssembler.transform.position, player.transform.position);

        if (distanceToyAssembler <= 3)
        {
            // Sets canvas to be active, if player is within range
            canvasToyAssembler.SetActive(true);
            // Allows the player to interact if the press E and have the materials.
            if (playerHasTheMaterials && Input.GetKeyDown(KeyCode.E))
            {
                // Sets bool to be true if the player has interacted with the table.
                toyAssembler.GetComponent<ToyAssembly>().assemble = true;
            }
        }
        else
        {
            // Sets the canvas to be in active if the player is anything otehr than within range.
            canvasToyAssembler.SetActive(false);
        }

        distanceNailStation = Vector3.Distance(nailStation.transform.position, player.transform.position);

        if (distanceNailStation <= 3)
        {
            // Sets canvas to be active, if player is within range
            canvasNailStation.SetActive(true);
            // Allows the player to interact if the press E and have the materials.
            if (playerHasTheMaterials && Input.GetKeyDown(KeyCode.E))
            {
                // Sets bool to be true if the player has interacted with the table.
                nailStation.GetComponent<RapidPresser>().gameHasStarted = true;
            }
        }
        else
        {
            // Sets the canvas to be in active if the player is anything otehr than within range.
            canvasNailStation.SetActive(false);
        }
    }
}
