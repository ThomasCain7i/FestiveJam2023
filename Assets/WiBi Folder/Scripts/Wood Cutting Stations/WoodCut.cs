using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCut : MonoBehaviour
{
    [SerializeField] GameObject station;
    [SerializeField] GameObject wood;
    [SerializeField] GameObject spawnBack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            wood.transform.position = spawnBack.transform.position;
            wood.transform.rotation = spawnBack.transform.rotation;
            wood.SetActive(false);
            station.GetComponent<WoodCutting>().beginCutting = false;
        }
    }
}
