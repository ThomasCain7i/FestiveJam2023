using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Assemble : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject stationCam;

    [SerializeField] LayerMask nailMask;
    [SerializeField] int nail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, nailMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (Input.GetButtonDown("Fire"))
            {
                if (hit.collider != null)
                {
                    // Add a tag to your object and use use CompareTag for better performace.
                    if (hit.collider.CompareTag("Nail"))
                    {
                        hit.collider.gameObject.GetComponent<Animator>().SetBool("Hit", true);
                        nail += 1;
                    }
                }
            }
        }
        if (nail >= 4)
        {
            Invoke(nameof(Done), 0.5f);
        }
    }

    void Done()
    {
        player.SetActive(true);
        cam.SetActive(true);
        stationCam.SetActive(false);
    }
}
