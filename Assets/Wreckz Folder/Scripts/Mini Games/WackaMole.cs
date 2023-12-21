using TMPro;  // Import TextMeshPro namespace
using UnityEngine;

public class WackaMole : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] GameObject canvasWackaMole;
    [SerializeField] GameObject up, left, right, down;

    [Header("Text")]
    [SerializeField] GameObject interactText;
    [SerializeField] GameObject instructionText, winText;
    [SerializeField] TextMeshProUGUI timerTextTMP;  // Change the variable type to TextMeshProUGUI
    [SerializeField] TextMeshProUGUI rewardTextTMP;  // Change the variable type to TextMeshProUGUI

    [Header("Bools")]
    public bool gameHasStarted;
    [SerializeField] bool gameIsPlaying, gameIsWon;

    [Header("Timers")]
    [SerializeField] float timeBetweenMoles;
    [SerializeField] float normalTimeBetweenMoles, timeLeft, timeLeftNormal, gameIsWonTimer;

    [Header("Score")]
    [SerializeField] int currentScore;
    [SerializeField] int maxScore;

    [Header("Reference")]
    [SerializeField] PlayerCam cam;
    [SerializeField] Inventory inventory;

    // Update is called once per frame
    void Update()
    {
        // Check if the game has started and not yet won
        if (gameHasStarted && !gameIsWon)
        {
            interactText.SetActive(false);
            cam.sensX = 5;
            cam.sensY = 5;
            timerTextTMP.gameObject.SetActive(true);

            if (!gameIsPlaying)
            {
                instructionText.SetActive(true);
            }

            // Check for the E key press to start the game
            if (Input.GetKeyDown(KeyCode.Mouse0) && !gameIsPlaying)
            {
                gameIsPlaying = true;
                instructionText.SetActive(false);
            }

            // Check if the game is actively playing
            if (gameIsPlaying)
            {
                canvasWackaMole.SetActive(true);

                // Update timers
                timeBetweenMoles -= Time.deltaTime;
                timeLeft -= Time.deltaTime;

                // Check if time is up, then lose the game
                if (timeLeft <= 0)
                {
                    LoseMiniGame();
                }

                // Update timer text using TextMeshProUGUI
                timerTextTMP.text = "Time: " + Mathf.RoundToInt(timeLeft).ToString();

                // Lock and show the cursor
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

                // Spawn a new mole after a certain time
                if (timeBetweenMoles <= 0)
                {
                    int rando = Random.Range(1, 5);

                    // Activate the corresponding mole based on random number
                    if (rando == 1)
                    {
                        up.SetActive(true);
                        down.SetActive(false);
                        left.SetActive(false);
                        right.SetActive(false);
                        timeBetweenMoles = normalTimeBetweenMoles;
                    }
                    else if (rando == 2)
                    {
                        up.SetActive(false);
                        down.SetActive(true);
                        left.SetActive(false);
                        right.SetActive(false);
                        timeBetweenMoles = normalTimeBetweenMoles;
                    }
                    else if (rando == 3)
                    {
                        up.SetActive(false);
                        down.SetActive(false);
                        left.SetActive(true);
                        right.SetActive(false);
                        timeBetweenMoles = normalTimeBetweenMoles;
                    }
                    else if (rando == 4)
                    {
                        up.SetActive(false);
                        down.SetActive(false);
                        left.SetActive(false);
                        right.SetActive(true);
                        timeBetweenMoles = normalTimeBetweenMoles;
                    }
                }

                // Check if the player has reached the maximum score to win
                if (currentScore >= maxScore && !gameIsWon)
                {
                    WinMiniGameTimer();
                }
            }
        }

        // Check if the game has been won, then initiate the win timer
        if (gameIsWon)
        {
            gameIsWonTimer -= Time.deltaTime;

            // When the win timer reaches 0, call WinMiniGame()
            if (gameIsWonTimer <= 0)
            {
                WinMiniGame();
            }
        }
    }

    // Called when one of the mole buttons is pressed
    public void PressedButton()
    {
        currentScore += 1;
        up.SetActive(false);
        down.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
    }

    // Initiates the win timer and sets up the win state
    void WinMiniGameTimer()
    {
        int reward = Random.Range(1, 6);
        rewardTextTMP.gameObject.SetActive(true);
        rewardTextTMP.text = ("Gained ") + reward + (" Wool");
        inventory.wool += reward;

        cam.sensX = cam.savedSensX;
        cam.sensY = cam.savedSensY;

        gameIsWonTimer = 5;
        winText.SetActive(true);
        gameIsWon = true;
        up.SetActive(false);
        down.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);

        timerTextTMP.gameObject.SetActive(false); // Hide the timer text
        instructionText.SetActive(false);

        // Unlock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Called when the win timer reaches 0 to complete the win state
    void WinMiniGame()
    {
        inventory.hasCloth = false;
        winText.SetActive(false);
        gameHasStarted = false;
        gameIsPlaying = false;
        gameIsWon = false;
        currentScore = 0;
        timeLeft = timeLeftNormal;
        interactText.SetActive(true);
        canvasWackaMole.SetActive(false);
        rewardTextTMP.gameObject.SetActive(false);

        Debug.Log("Won Fur Minigame");
    }

    // Called when the time limit is reached, initiating the lose state
    void LoseMiniGame()
    {
        cam.sensX = cam.savedSensX;
        cam.sensY = cam.savedSensY;

        up.SetActive(false);
        down.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
        gameHasStarted = false;
        gameIsPlaying = false;
        currentScore = 0;
        timeLeft = timeLeftNormal;
        timerTextTMP.gameObject.SetActive(false); // Hide the timer text
        interactText.SetActive(true);
        instructionText.SetActive(false);
        rewardTextTMP.gameObject.SetActive(false);

        Debug.Log("Lost Nail Minigame");
    }
}
