using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was created by Liam Wilson
// For the purpose of simply looking towards the player

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // Collects the player object and assigns it accordingly
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Code to look at the player
        transform.LookAt(player.transform.position);
    }
}
