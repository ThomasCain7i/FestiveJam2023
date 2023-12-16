using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos.position;
    }
}
