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
