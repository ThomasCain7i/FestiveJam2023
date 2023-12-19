using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintClicker : MonoBehaviour
{
    [SerializeField] bool alreadyGotBlueprint;
    [SerializeField] GameObject cam;
    [SerializeField] LayerMask blueprint;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, blueprint))
        {
            //Debug.Log("Hit");

            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            if (Input.GetButtonDown("Fire"))
            {
                //Debug.Log("Hit after clicked");
                if (hit.collider != null)
                {
                    if (!alreadyGotBlueprint)
                    {
                        // Code to call function on blueprint which gives the player the blueprint
                        int b = hit.collider.gameObject.GetComponent<BlueprintID>().id;
                        hit.collider.gameObject.GetComponent<BlueprintGiver>().Blueprints(b);
                        alreadyGotBlueprint = true;
                    }
                    
                }
            }
        }
    }
}
