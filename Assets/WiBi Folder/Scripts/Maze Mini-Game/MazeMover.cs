using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMover : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("MazeHorizontal");
        verticalInput = Input.GetAxisRaw("MazeVertical");
        Vector3 i = new Vector3(horizontalInput, verticalInput);
        i.Normalize();

        transform.Translate(i * speed * Time.deltaTime);
    }
}
