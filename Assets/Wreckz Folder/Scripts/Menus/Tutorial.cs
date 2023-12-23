using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject tutorial;

    [SerializeField] PlayerCam cam;

    private void Start()
    {
        cam.SaveSens();
        cam.sensX = 0;
        cam.sensY = 0;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Update is called once per frame
    public void CloseTutorial()
    {
        cam.sensX = cam.savedSensX;
        cam.sensY = cam.savedSensY;

        tutorial.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
