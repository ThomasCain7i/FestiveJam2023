using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This script was created by Liam Wilson
// For the purpose of moving and rotateing the Station Camera

// !!! THIS SCRIPT IS NO LONGER USED !!!

public class SsemblyCameraMove : MonoBehaviour
{
    [Header("Floats")]
    float horizontalInput;
    float verticalInput;
    float speed = 5;

    [SerializeField] float sensX;
    [SerializeField] float sensY;

    float xRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        // Sets the cursor to be locked
        Cursor.lockState = CursorLockMode.Locked;
        // and invisible
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Calls the necessary functions
        CamMove();
        CamRotate();
    }

    // Function to store the camera movement
    void CamMove()
    {
        // Always changes the float values based on input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        // Sets a vector 3 variable based on input collected - constantly updated
        Vector3 i = new Vector3(horizontalInput, 0, verticalInput);
        // Normalize the input
        i.Normalize();

        // Move the object based on the input
        transform.Translate(i * speed * Time.deltaTime);
    }

    // Function to store the camera rotation
    void CamRotate()
    {
        // Change the floats based on the input, with added sensitivity
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        // Adds the mouse input onto the already calculated yRotation float
        yRotation += mouseX;
        // Removes the mouse input from the float
        xRotation -= mouseY;
        // Prevents the camera from rotating
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        // Sets the camers rotation based on the input and equastions above.
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
