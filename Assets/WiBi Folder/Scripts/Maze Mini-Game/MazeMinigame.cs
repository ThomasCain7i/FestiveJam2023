using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMinigame : MonoBehaviour
{
    [SerializeField] GameObject spawn;
    [SerializeField] GameObject[] premadeMazes;
    [SerializeField] GameObject maze, mazeLid;
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
        maze = Instantiate(premadeMazes[r]);
        maze.transform.position = spawn.transform.position;
        maze.transform.rotation = spawn.transform.rotation;
        maze.transform.parent = spawn.transform;
    }

    public void DeleteMaze()
    {
        Destroy(maze);
        mazeLid.SetActive(false);
    }
}
