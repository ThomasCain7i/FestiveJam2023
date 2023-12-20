using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeObjective : MonoBehaviour
{
    [Header("GameObjects & References")]
    [SerializeField] GameObject wrapStation;
    [Header("Bools")] 
    [SerializeField] bool wrappingStation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            if (wrappingStation)
            {
                wrapStation.SetActive(true);
                //wrapStation.GetComponent<WrappingStation>().toyPlaced = true;
                
            }
        }
    }
}
