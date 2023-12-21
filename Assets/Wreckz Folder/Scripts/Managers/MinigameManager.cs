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
    [SerializeField] GameObject woodStation;
    [SerializeField] GameObject nailStation;
    [SerializeField] GameObject toyAssembler;
    [SerializeField] GameObject wrapStation;
    [SerializeField] GameObject clothstation;

    [Header("Distance")]
    [SerializeField] float distanceWoodStation;
    [SerializeField] float distanceNailStation;
    [SerializeField] float distanceToyAssembler;
    [SerializeField] float distanceWrapStation;
    [SerializeField] float distanceFurStation;
    [SerializeField] float howFar;

    [Header("Canavs")]
    [SerializeField] GameObject canvasWoodStation;
    [SerializeField] GameObject canvasNailStation;
    [SerializeField] GameObject canvasToyAssembler;
    [SerializeField] GameObject canvasWrapStation;
    [SerializeField] GameObject canvasFurStation;

    [Header("Materials")]
    [SerializeField] bool hasMatsBuild, hasMatsWrap;

    [Header("References")]
    [SerializeField] Inventory inventory;

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
        if (woodStation != null)
        {
            distanceWoodStation = Vector3.Distance(woodStation.transform.position, player.transform.position);

            if (distanceWoodStation <= howFar)
            {
                // Sets canvas to be active, if player is within range
                canvasWoodStation.SetActive(true);
                // Allows the player to interact if the press E and have the materials.
                if (Input.GetKeyDown(KeyCode.E))
                {
                    woodStation.GetComponent<WoodCutting>().beginCutting = true;
                }
            }
            else
            {
                // Sets the canvas to be in active if the player is anything otehr than within range.
                canvasWoodStation.SetActive(false);
            }
        }

        if (toyAssembler != null)
        {
            // Constantly getting the distance between, the toyAssembler gameObject and the player
            distanceToyAssembler = Vector3.Distance(toyAssembler.transform.position, player.transform.position);

            if (distanceToyAssembler <= howFar)
            {
                // Sets canvas to be active, if player is within range
                canvasToyAssembler.SetActive(true);
                // Allows the player to interact if the press E and have the materials.
                if (hasMatsBuild && Input.GetKeyDown(KeyCode.E))
                {
                    // Sets bool to be true if the player has interacted with the table.
                    toyAssembler.GetComponent<ToyAssembly>().gameHasStarted = true;
                }
            }
            else
            {
                // Sets the canvas to be in active if the player is anything otehr than within range.
                canvasToyAssembler.SetActive(false);
            }
        }

        if (nailStation != null)
        {
            distanceNailStation = Vector3.Distance(nailStation.transform.position, player.transform.position);

            if (distanceNailStation <= howFar)
            {
                // Sets canvas to be active, if player is within range
                canvasNailStation.SetActive(true);
                // Allows the player to interact if the press E and have the materials.
                if (inventory.hasMetal && Input.GetKeyDown(KeyCode.E))
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

        if (wrapStation != null)
        {
            distanceWrapStation = Vector3.Distance(wrapStation.transform.position, player.transform.position);

            if (distanceWrapStation <= howFar)
            {
                // Sets canvas to be active, if player is within range
                canvasWrapStation.SetActive(true);
                // Allows the player to interact if the press E and have the materials.
                if (hasMatsWrap && Input.GetKeyDown(KeyCode.E))
                {
                    // Sets bool to be true if the player has interacted with the table.
                    wrapStation.GetComponent<WrappingStation>().BeginWrapping();
                }
            }
            else
            {
                // Sets the canvas to be in active if the player is anything otehr than within range.
                canvasWrapStation.SetActive(false);
            }
        }

        if (clothstation != null)
        {
            distanceFurStation = Vector3.Distance(clothstation.transform.position, player.transform.position);

            if (distanceFurStation <= howFar)
            {
                // Sets canvas to be active, if player is within range
                canvasFurStation.SetActive(true);
                // Allows the player to interact if the press E and have the materials.
                if (inventory.hasCloth && Input.GetKeyDown(KeyCode.E))
                {
                    // Sets bool to be true if the player has interacted with the table.
                    clothstation.GetComponent<WackaMole>().gameHasStarted = true;
                }
            }
            else
            {
                // Sets the canvas to be in active if the player is anything otehr than within range.
                canvasFurStation.SetActive(false);
            }
        }
    }
}
