using UnityEngine;
using TMPro;

public class RapidPresser : MonoBehaviour
{
    [Header("Mini Game Specific Variables")]
    [SerializeField] int numToWin, currentNumber;
    [SerializeField] float timer;
    public bool timerHasStarted, gameHasStarted;

    [Header("Game Manager")]
    [SerializeField] Gamemanager gamemanager;

    [Header("Canvas")]
    [SerializeField] GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHasStarted)
        {
            canvas.SetActive (true);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartMiniGame();
            }
        }

        if (timerHasStarted)
        {
            timer -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                currentNumber += 1;

                if (currentNumber == numToWin && timer > 0)
                {
                    WinMiniGame();
                }

                if (currentNumber < numToWin | timer <= 0)
                {
                    LoseMiniGame();
                }
            }
        }
    }

    void StartMiniGame()
    {
        timerHasStarted = true;
    }
    
    void WinMiniGame()
    {

    }

    void LoseMiniGame()
    {

    }
}
