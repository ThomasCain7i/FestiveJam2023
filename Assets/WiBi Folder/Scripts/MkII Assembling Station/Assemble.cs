using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

// This script was created by Liam Wilson.
// For the purpose of hammering in the nails, on the MkII assembly bench

// !!! CURRENTLY NOT USED WITHIN GAME !!!

public class Assemble : MonoBehaviour
{
    [Header("GameObject & References")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject stationCam;

    [Header("Nail Variabls")]
    [SerializeField] LayerMask nailMask;
    [SerializeField] int nail;

    // Update is called once per frame
    void Update()
    {
        // Raycast to register if the player is looking at a nail object
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, nailMask))
        {
            // Draw ray for debugging purposes.
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            // If statement to register input.
            if (Input.GetButtonDown("Fire"))
            {
                // If statement to register if a collider withing the disclosed layer has been hit / detected
                if (hit.collider != null)
                {
                    // Code to enable an animation for better viewing purposes
                    hit.collider.gameObject.GetComponent<Animator>().SetBool("Hit", true);
                    // adds a nail to total
                    nail += 1;
                }
            }
        }
        // This bit was temp. Cause it was simple, and we wasn't sure if we was gunna use this or not.
        // checks if all nails have been hammered.
        if (nail >= 4)
        {
            // Code to add delay
            Invoke(nameof(Done), 0.5f);
        }
    }
    // Function to run end assemble
    void Done()
    {
        // Sets player active
        player.SetActive(true);
        // Sets player cam active
        cam.SetActive(true);
        // Sets station cam active
        stationCam.SetActive(false);
    }
}
