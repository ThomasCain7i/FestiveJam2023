using UnityEngine;
using TMPro;

public class RapidPresser : MonoBehaviour
{
    [Header("Mini Game Specific Variables")]
    [SerializeField] int numToWin;
    [SerializeField] int currentNumber;
    [SerializeField] float timer, winTimer;
    public bool timerHasStarted, gameHasStarted, gameIsPlaying, gameIsWon;

    [Header("References")]
    [SerializeField] MinigameManager minigameManager;
    [SerializeField] Inventory inventory;

    [Header("Canvas")]
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject interactText, instructionText, winText;
    [SerializeField] TextMeshProUGUI scoreText; // Assuming scoreText is a TextMeshPro component
    [SerializeField] TextMeshProUGUI timerText; // Add this for the timer text
    [SerializeField] TextMeshProUGUI rewardText; // Add this for the timer text

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false); // Initially hide the timer text
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHasStarted && !gameIsWon)
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

        if (timerHasStarted && !gameIsWon)
        {
            timer -= Time.deltaTime;

            // Update the timer text and color
            timerText.text = timer.ToString("F1"); // Display timer with one decimal place

            // Change the color based on remaining time
            if (timer > 2.0f)
            {
                timerText.color = Color.green;
            }
            else
            {
                timerText.color = Color.red;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                currentNumber += 1;

                FMODUnity.RuntimeManager.PlayOneShot("event:/nail station\r\n");

                if (currentNumber == numToWin && timer > 0)
                {
                    WinMiniGameTimer();
                }

                if (currentNumber < numToWin && timer <= 0)
                {
                    LoseMiniGame();
                }
            }
        }

        if (gameIsWon)
        {
            winTimer -= Time.deltaTime;

            if (winTimer <= 0)
            {
                WinMiniGame();
            }
        }
    }

    void StartMiniGame()
    {
        timerHasStarted = true;
        gameIsPlaying = true;
        scoreText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(true); // Show the timer text
        Debug.Log("Starting Nail Minigame");
    }

    void WinMiniGameTimer()
    {
        int reward = Random.Range(1, 6);
        rewardText.gameObject.SetActive(true);
        rewardText.text = ("Gained ") + reward + (" Nails");
        inventory.nails += reward;

        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false); // Hide the timer text
        instructionText.SetActive(false);

        winTimer = 5;
        winText.SetActive(true);
        gameIsWon = true;
    }

    void WinMiniGame()
    {
        inventory.hasMetal = false;
        winText.SetActive(false);
        gameHasStarted = false;
        timerHasStarted = false;
        gameIsPlaying = false;
        gameIsWon = false;
        currentNumber = 0;
        timer = 5;
        interactText.SetActive(true);
        rewardText.gameObject.SetActive(false);

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
        timerText.gameObject.SetActive(false); // Hide the timer text
        interactText.SetActive(true);
        instructionText.SetActive(false);
        rewardText.gameObject.SetActive(false);

        Debug.Log("Lost Nail Minigame");
    }
}
