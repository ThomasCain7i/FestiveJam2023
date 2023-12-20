using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was created by Liam Wilson
// For the purpose of rotating the blade for the wood cutting bench

public class BladeRotation : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        // Rotates the object this script is attached too
        transform.Rotate(0, 0, 100 * speed * Time.deltaTime);
    }
}
