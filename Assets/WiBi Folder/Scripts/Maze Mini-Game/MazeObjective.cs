using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeObjective : MonoBehaviour
{
    [Header("GameObjects & References")]
    [SerializeField] GameObject wrapStation;
    [SerializeField] GameObject mazeObj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") )
        {
            wrapStation = GameObject.FindGameObjectWithTag("WrapStation");
            wrapStation.GetComponent<WrappingStation>().mazeDone = true;

            Destroy(mazeObj);
        }
    }
}
