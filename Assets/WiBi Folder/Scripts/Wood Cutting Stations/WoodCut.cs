using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was created by Liam Wilson
// For the purpose of controling the end conditions and results

public class WoodCut : MonoBehaviour
{
    [Header("GameObjects & References")]
    [SerializeField] GameObject station;
    [SerializeField] GameObject wood;
    [SerializeField] GameObject spawnBack;

    // A trigger for detecting the fallen wood
    private void OnTriggerEnter(Collider other)
    {
        // Checks to make sure the object which has entered is indeed wood
        if (other.gameObject.CompareTag("Wood"))
        {
            // Sets the woods position and rotation to that of the spawnBack object
            wood.transform.position = spawnBack.transform.position;
            wood.transform.rotation = spawnBack.transform.rotation;
            // Sets the wood to be inactive for use next time.
            wood.SetActive(false);
            // Sets the wood cutting bool to be false
            station.GetComponent<WoodCutting>().beginCutting = false;

            // Code to set playerHasWood bool false within the inventory script,
            // Code to set playerHasPlanks bool true within the inventory script,
            // Only when they pick it up from the collection area.
        }
    }
}
