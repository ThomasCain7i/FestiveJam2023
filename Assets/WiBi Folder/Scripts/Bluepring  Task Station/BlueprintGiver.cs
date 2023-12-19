using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was created by Liam Wilson.
// For the purpose of assigning the player blueprints to build.

public class BlueprintGiver : MonoBehaviour
{
    [SerializeField] GameObject[] blueprint;
    public void Blueprints(int b)
    {
        if(b == 250)
        {
            int r = Random.Range(0, blueprint.Length);
            blueprint[r].SetActive(true);
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
}
