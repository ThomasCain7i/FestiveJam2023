using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMinigame : MonoBehaviour
{
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject[] premadeMazes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnMaze()
    {
        int r = Random.Range(0, premadeMazes.Length);
        GameObject m = Instantiate(premadeMazes[r]);
        m.transform.position = spawn.transform.position;
        m.transform.rotation = spawn.transform.rotation;
        m.transform.parent = spawn.transform;
        m.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }
}
