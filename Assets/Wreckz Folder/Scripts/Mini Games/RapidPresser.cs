using UnityEngine;
using TMPro;

public class RapidPresser : MonoBehaviour
{
    [Header("Mini Game Specific Variables")]
    [SerializeField] int numToWin, currentNumber;
    [SerializeField] float timer;
    public bool timerHasStarted, gameHasStarted, gameIsPlaying;

    [Header("Game Manager")]
    [SerializeField] MinigameManager minigameManager;

    [Header("Canvas")]
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject interactText, instructionText;
    [SerializeField] TextMeshProUGUI scoreText; // Assuming scoreText is a TextMeshPro component

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHasStarted)
        {
            canvas.SetActive(true);

            interactText.SetActive(false);
            instructionText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Mouse0) && gameIsPlaying == false)
            {
                StartMiniGame();
            }

            // Set the text of the scoreText to the currentNumber
            scoreText.text = currentNumber.ToString();
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

                if (currentNumber < numToWin && timer <= 0)
                {
                    LoseMiniGame();
                }
            }
        }
    }

    void StartMiniGame()
    {
        timerHasStarted = true;
        gameIsPlaying = true;
        scoreText.gameObject.SetActive(true);
        Debug.Log("Starting Nail Minigame");
    }

    void WinMiniGame()
    {
        gameHasStarted = false;
        timerHasStarted = false;
        gameIsPlaying = false;
        currentNumber = 0;
        timer = 5;
        scoreText.gameObject.SetActive(false);
        interactText.SetActive(true);
        instructionText.SetActive(false);
        Debug.Log("Won Nail Minigame");
    }

    void LoseMiniGame()
    {
        gameHasStarted = false;
        timerHasStarted = false;
        gameIsPlaying = false;
        currentNumber = 0;
        timer = 5;
        scoreText.gameObject.SetActive(false);
        interactText.SetActive(true);
        instructionText.SetActive(false);
        Debug.Log("Lost Nail Minigame");
    }
}
