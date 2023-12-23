using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public bool isPaused;

    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] GameObject endGameScreen;
    public bool builtAll3;
    public bool disable;

    // Start is called before the first frame update
    void Start()
    {
        endGameScreen.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (builtAll3 && !disable)
        {
            endGameScreen.SetActive(true);
        }
    }

    public void DisableCongratsScreen()
    {
        disable = true;
        endGameScreen.SetActive(false);
    }
}
