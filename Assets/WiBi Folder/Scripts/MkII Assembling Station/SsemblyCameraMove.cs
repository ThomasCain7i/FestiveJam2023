using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SsemblyCameraMove : MonoBehaviour
{
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        CamMove();
        CamRotate();
    }

    void CamMove()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 i = new Vector3(horizontalInput, 0, verticalInput);
        i.Normalize();

        transform.Translate(i * speed * Time.deltaTime);
    }
    void CamRotate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
