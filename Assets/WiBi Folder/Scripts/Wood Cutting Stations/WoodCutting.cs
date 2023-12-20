using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutting : MonoBehaviour
{
    [Header("GameObjects & References")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject wood;
    [SerializeField] GameObject canvas;
    [Header("Bool & Numbers")]
    public bool beginCutting;
    [SerializeField] float dist;
    [SerializeField] bool playerHasWood;
    [SerializeField] float speed;
    private void Start()
    {
        // Collects the player object
        player = GameObject.FindGameObjectWithTag("Player");
        // Sets canvas to be inactive
        canvas.SetActive(false);
    }
    private void Update()
    {
        // Constantly grabs the distance between the player and this object
        dist = Vector3.Distance(player.transform.position, transform.position);
        // Checks to make sure the player is within range
        if(dist <= 3)
        {
            // Sets the canvas to be active
            canvas.SetActive(true);
            // Checks to make sure the player has wood and has presse E
            if (playerHasWood && Input.GetKeyDown(KeyCode.E))
            {
                // Sets begins cutting bool to be true
                beginCutting = true;
            }
        }
        else
        {
            // Sets canvas to be inactive if the player is not within distance
            canvas.SetActive(false);
        }
        // Calls the cutting wood function
        CutWood();
    }

    // Function to control and store the cutting wood mechancis
    void CutWood()
    {
        if (beginCutting)
        {
            // Set wood to be active
            wood.SetActive(true);
            // Move wood accross the table in the correct direction
            wood.transform.position += new Vector3(0, 0, 0.5f * speed * Time.deltaTime);

            // Enable it so that audio plays when cutting
        }
    }
}
