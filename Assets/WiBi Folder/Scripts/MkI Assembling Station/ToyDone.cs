using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class ToyDone : MonoBehaviour
{
    // Bool collected from toy assembler for when toy is finished
    public bool toyDone;
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        if (toyDone)
        {
            // Delays the moving of the toy
            Invoke(nameof(Delay), 0.5f);
        }
    }
    // Function to allow for a delay and run the movment code
    void Delay()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
