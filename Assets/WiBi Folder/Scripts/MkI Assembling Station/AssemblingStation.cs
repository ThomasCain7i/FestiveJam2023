using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblingStation : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject toyAssembler;

    [SerializeField] float dist;
    [SerializeField] int toySelected;
    [SerializeField] bool playerHasTheMaterials;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        if(dist <= 3)
        {
            canvas.SetActive(true);
            if (playerHasTheMaterials && Input.GetKeyDown(KeyCode.E))
            {
                toyAssembler.GetComponent<ToyAssembly>().assemble = true;
            }
        }
        else
        {
            canvas.SetActive(false);
        }
    }
}
