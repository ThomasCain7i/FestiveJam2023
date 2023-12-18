using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class ToyDone : MonoBehaviour
{
    public bool toyDone;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toyDone)
        {
            Invoke(nameof(Delay), 0.5f);
        }
    }
    void Delay()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
