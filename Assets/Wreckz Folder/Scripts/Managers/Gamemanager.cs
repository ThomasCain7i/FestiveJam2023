using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public bool isPaused;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] bool builtAll3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (builtAll3)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
