using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was created by Liam Wilson
// For the purpose of the player interaction with the wrapping station

public class WrappingStation : MonoBehaviour
{
    [Header("GameObjects & References")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerCam;
    [SerializeField] GameObject stationCam;

    [SerializeField] GameObject[] toys;

    [SerializeField] int blueprintId;
    public bool toyPlaced;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stationCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginWrapping()
    {
        player.SetActive(false);
        playerCam.SetActive(false);
        stationCam.SetActive(true);
        gameObject.GetComponent<MazeMinigame>().SpawnMaze();
    }

    void WrapPresent(int b)
    {
        if (toyPlaced)
        {
            toys[b].SetActive(true);
            // Insert the mini-game
        }
    }

    // Function to finish using the wrapping station and reset the system
    public void WrapUpWrapping()
    {
        player.SetActive(true);
        playerCam.SetActive(true);
        stationCam.SetActive(false);
        
    }
}
