using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was created by Liam Wilson
// For the purpose of collecting the toy and storing the toy once made.


public class CollectionBoxTrigger : MonoBehaviour
{
    [Header("Spawn Toy")]
    [SerializeField] GameObject toySpawn;
    [Header("Bool & Numbers")]
    [SerializeField] int childCount;
    [SerializeField] bool toyMade;

    // A trigger function, for registering if something has entered the trigger.
    private void OnTriggerEnter(Collider other)
    {
        // If statement for checking if that 'something', slightly resembles a toy
        if (other.gameObject.CompareTag("Toy"))
        {
            //Debug.Log("Toy Hit Trigger");
            // Assigning the objects collider, for later reference
            Collider c = other.gameObject.GetComponent<Collider>();
            // If statement to check and hope the collider is not empty
            if (c != null)
            {
                //Debug.Log("Toy Collected");
                // Sets object to be in active
                c.gameObject.SetActive(false);
                // Sends a message to another script on whether the toy is done or not.
                c.gameObject.GetComponent<ToyDone>().toyDone = false;
                // Sets true for later use
                toyMade = true;
                //Debug.Log("Toy Made!");
                // Checks whether the toy made is true
                if (toyMade)
                {
                    // Finds all children of the toys parents
                    childCount = c.transform.childCount;
                    // Loops for the amount of childrent the parent object has
                    for (int i = 0; i < childCount; i++)
                    {
                        // Sets all children to be in active
                        c.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    // Sets parent object to be true again
                    c.gameObject.SetActive(true);
                    // Moves position and rotation of toy parent to match that of the toy spawn object
                    c.gameObject.transform.position = toySpawn.transform.position;
                    c.gameObject.transform.rotation = toySpawn.transform.rotation;
                    // Sets toymade to be false, in order to restart the process and
                    // not loop this if statement until needed
                    toyMade = false;
                }
            }
        }
    }
}
