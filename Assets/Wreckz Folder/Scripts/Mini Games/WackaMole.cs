using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WackaMole : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] GameObject canvasWackaMole;
    [SerializeField] GameObject up, left, right, down;

    [Header("Text")]
    [SerializeField] GameObject interactText;
    [SerializeField] GameObject instructionText, winText, timerText;

    [Header("Bools")]
    public bool gameHasStarted;
    [SerializeField] bool gameIsPlaying, gameIsWon;

    [Header("Timers")]
    [SerializeField] float timeBetweenMoles;
    [SerializeField] float normalTimeBetweenMoles, timeLeft, timeLeftNormal, gameIsWonTimer;

    [Header("Score")]
    [SerializeField] int currentScore;
    [SerializeField] int maxScore;

    // Update is called once per frame
    void Update()
    {
        if (gameHasStarted && !gameIsWon)
        {
            interactText.SetActive(false);
            instructionText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                gameIsPlaying = true;
                instructionText.SetActive(false);

            }

            if (gameIsPlaying)
            {
                canvasWackaMole.SetActive(true);

                timeBetweenMoles -= Time.deltaTime;

                timerText.SetActive(true);

                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

                if (timeBetweenMoles <= 0)
                {
                    int rando = Random.Range(1, 4);


                    if (rando == 1)
                    {
                        up.SetActive(true);
                        down.SetActive(false);
                        left.SetActive(false);
                        right.SetActive(false);
                        timeBetweenMoles = normalTimeBetweenMoles;
                    }

                    if (rando == 2)
                    {
                        up.SetActive(false);
                        down.SetActive(true);
                        left.SetActive(false);
                        right.SetActive(false);
                        timeBetweenMoles = normalTimeBetweenMoles;
                    }

                    if (rando == 3)
                    {
                        up.SetActive(false);
                        down.SetActive(false);
                        left.SetActive(true);
                        right.SetActive(false);
                        timeBetweenMoles = normalTimeBetweenMoles;
                    }

                    if (rando == 4)
                    {
                        up.SetActive(false);
                        down.SetActive(false);
                        left.SetActive(false);
                        right.SetActive(true);
                        timeBetweenMoles = normalTimeBetweenMoles;
                    }
                }

                if (currentScore >= maxScore && !gameIsWon)
                {
                    WinMiniGameTimer();
                }
            }
        }

        if (gameIsWon)
        {
            gameIsWonTimer -= Time.deltaTime;

            if (gameIsWonTimer <= 0)
            {
                WinMiniGame();
            }
        }
    }

    public void PressedButton()
    {
        currentScore += 1;
        up.SetActive(false);
        down.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);
    }

    void WinMiniGameTimer()
    {
        gameIsWonTimer = 5;
        winText.SetActive(true);
        gameIsWon = true;

        timerText.gameObject.SetActive(false); // Hide the timer text
        instructionText.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void WinMiniGame()
    {
        winText.SetActive(false);
        gameHasStarted = false;
        gameHasStarted = false;
        gameIsPlaying = false;
        gameIsWon = false;
        currentScore = 0;
        timeLeft = timeLeftNormal;
        interactText.SetActive(true);
        canvasWackaMole.SetActive(false);

        Debug.Log("Won Fur Minigame");
    }
}
