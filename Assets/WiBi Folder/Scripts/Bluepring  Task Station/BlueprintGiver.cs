using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was created by Liam Wilson.
// For the purpose of assigning the player blueprints to build.

public class BlueprintGiver : MonoBehaviour
{
    [Header("Blueprint Canvas Objects")]
    [SerializeField] GameObject[] blueprint;
    // Function called from another script which passes in the blueprint id. 
    public void Blueprints(int b)
    {
        if(b == 250)
        {
            // Code to randomly select a blueprint if players wish.
            int randomBlueprint = Random.Range(0, blueprint.Length);
            blueprint[randomBlueprint].SetActive(true);
        }
        else if (b == 0)
        {
            // Give Train
            Debug.Log("Train Blueprint Given");
            blueprint[b].SetActive(true);
        }
        else if (b == 1)
        {
            // Give Bear
            Debug.Log("Bear Blueprint Given");
            blueprint[b].SetActive(true);
        }
    }

    // Function to called to reset blueprints
    public void DoneBlueprint()
    {
        int a = 0;
        for (int i = 0; i < blueprint.Length; i++)
        {
            blueprint[a].SetActive(false);
            a += 1;
        }
    }
}
