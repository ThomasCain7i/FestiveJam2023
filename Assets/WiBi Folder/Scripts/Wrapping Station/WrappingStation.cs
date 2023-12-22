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

    [SerializeField] GameObject blueprintStation;
    [SerializeField] GameObject spawn;

    [SerializeField] GameObject lid;
    [SerializeField] GameObject[] toys;

    [SerializeField] int blueprintId;
    public bool mazeDone;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stationCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        blueprintId = blueprintStation.GetComponent<BlueprintClicker>().blueprintId;
        WrapPresent(blueprintId);
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
        if (mazeDone)
        {
            //toys[b].SetActive(true);
            Debug.Log("Start Wrapping");

            // Move / Spawn toy into present box
            toys[b].SetActive(true);
            toys[b].GetComponent<Animator>().SetBool("Place", true);
            player.SetActive(true);
            playerCam.SetActive(true);
            stationCam.SetActive(false);
            // Close Lid / Cover Box
            FMODUnity.RuntimeManager.PlayOneShot("event:/wrapping station\r\n");
            lid.SetActive(true);
            Invoke(nameof(WrapUpWrapping), 0.5f);
            // Allow player to pick up present

        }
    }


    // Function to finish using the wrapping station and reset the system
    public void WrapUpWrapping()
    {
        lid.GetComponent<Animator>().SetBool("Go", true);
    }
}
