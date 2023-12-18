using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutting : MonoBehaviour
{
    [Header("GameObjects & References")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject wood;
    [SerializeField] GameObject canvas;
    public bool beginCutting;
    [SerializeField] float dist;
    [SerializeField] bool playerHasWood;
    [SerializeField] float speed;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas.SetActive(false);
    }
    private void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if(dist <= 3)
        {
            canvas.SetActive(true);
            if (playerHasWood && Input.GetKeyDown(KeyCode.E))
            {
                beginCutting = true;
            }
        }
        else
        {
            canvas.SetActive(false);
        }
        
        CutWood();
    }

    void CutWood()
    {
        if (beginCutting)
        {
            wood.SetActive(true);
            wood.transform.position += new Vector3(0, 0, 0.5f * speed * Time.deltaTime);
        }
    }
}
