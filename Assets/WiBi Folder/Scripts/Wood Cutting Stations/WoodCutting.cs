using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WoodCutting : MonoBehaviour
{
    [Header("Game Specific Variables")]
    [SerializeField] bool roundOne;
    [SerializeField] int randomPitch, currentRound, maxRound, numberWrong, maxWrong;
    [SerializeField] GameObject highHoObject, normalHoObject, lowHoObject, canvasWoodCutter;
    [SerializeField] float timeBetweenRounds, gameIsWonTimer;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    [Header("Bools")]
    public bool gameHasStarted;
    [SerializeField] bool gameIsPlaying, roundInProgress, gameIsWon, noisePlayed;

    [Header("Text")]
    [SerializeField] GameObject interactText;
    [SerializeField] GameObject instructionText, correctText, wrongText, winText;
    [SerializeField] TextMeshProUGUI rewardTextTMP;

    [Header("Extras")]
    [SerializeField] GameObject wood;
    public bool beginCutting;
    [SerializeField] float speed;
    [SerializeField] Inventory inventory;
    [SerializeField] PlayerCam cam;

    private FMOD.Studio.EventInstance santa;


    private void Start()
    {
        roundOne = true;
        santa = FMODUnity.RuntimeManager.CreateInstance("event:/ho-ho-ho");
    }

    private void Update()
    {
        if(gameHasStarted)
        {
            Debug.Log("Wood has started");

            if (!gameIsWon)
            {
                interactText.SetActive(false);
                instructionText.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0) && !gameIsWon)
            {
                gameIsPlaying = true;

                canvasWoodCutter.SetActive(true);

                Debug.Log("wood is playing");
            }

            if (gameIsPlaying && !gameIsWon)
            {
                // Lock and show the cursor
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;

                cam.sensX = 5;
                cam.sensY = 5;

                timeBetweenRounds -= Time.deltaTime;
            }

            if (gameIsPlaying && !roundInProgress && currentRound < maxRound && timeBetweenRounds <= 0)
            {
                correctText.SetActive(false);
                wrongText.SetActive(false);

                if (roundOne)
                {
                    roundInProgress = true;
                    randomPitch = Random.Range(1, 4);

                    Debug.Log(randomPitch);

                    if (randomPitch == 1 && !noisePlayed)
                    {
                        santa.setParameterByName("santa pitch", 2);
                        santa.start();
                        // Play high pitched noise
                        audioSource.pitch = 1.5f;
                        audioSource.PlayOneShot(audioClip);
                        noisePlayed = true;
                        Debug.Log("High Pitch Played");
                    }

                    if (randomPitch == 2 && !noisePlayed)
                    {
                        santa.setParameterByName("santa pitch", 1);
                        santa.start();
                        // Play normal pitched noise
                        audioSource.pitch = 1f;
                        audioSource.PlayOneShot(audioClip);
                        noisePlayed = true;
                        Debug.Log("Normal Pitch Played");
                    }

                    if (randomPitch == 3 && !noisePlayed)
                    {
                        santa.setParameterByName("santa pitch",0);
                        santa.start();
                        // Play low pitched noise
                        audioSource.pitch = .5f;
                        audioSource.PlayOneShot(audioClip);
                        noisePlayed = true;
                        Debug.Log("Low Pitch Played");
                    }
                }
            }

            if (currentRound == maxRound && !gameIsWon)
            {
                WinMiniGameTimer();
            }

            if (numberWrong == maxWrong && gameIsPlaying)
            {
                LoseMiniGame();
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

    public void HighPitchedHo()
    {
        if (timeBetweenRounds <= 0)
        {
            if (randomPitch == 1)
            {
                currentRound += 1;
                roundInProgress = false;
                timeBetweenRounds = 2;
                correctText.SetActive(true);
                instructionText.SetActive(false);
                noisePlayed = false;

                Debug.Log("HighPitchedCorrect");
            }
            else
            {
                numberWrong += 1;
                roundInProgress = false;
                timeBetweenRounds = 2;
                wrongText.SetActive(true);
                instructionText.SetActive(false);
                noisePlayed = false;

                Debug.Log("HighPitchedWrong");
            }
        }
    }

    public void NormalPitchedHo()
    {
        if(timeBetweenRounds <= 0)
        {
            if (randomPitch == 2)
            {
                currentRound += 1;
                roundInProgress = false;
                timeBetweenRounds = 2;
                correctText.SetActive(true);
                instructionText.SetActive(false);
                noisePlayed = false;

                Debug.Log("NormalPitchCorrect");
            }
            else
            {
                numberWrong += 1;
                roundInProgress = false;
                timeBetweenRounds = 2;
                wrongText.SetActive(true);
                instructionText.SetActive(false);
                noisePlayed = false;

                Debug.Log("NormalPitchWrong");
            }
        }
    }

    public void LowPitchedHo()
    {
        if(timeBetweenRounds <= 0)
        {
            if (randomPitch == 3)
            {
                currentRound += 1;
                roundInProgress = false;
                timeBetweenRounds = 2;
                correctText.SetActive(true);
                instructionText.SetActive(false);
                noisePlayed = false;

                Debug.Log("LowPitchCorrect");
            }
            else
            {
                numberWrong += 1;
                roundInProgress = false;
                timeBetweenRounds = 2;
                wrongText.SetActive(true);
                instructionText.SetActive(false);
                noisePlayed = false;

                Debug.Log("LowPitchWrong");
            }
        }
    }

    void WinMiniGameTimer()
    {
        gameHasStarted = false;

        int reward = Random.Range(1, 6);
        rewardTextTMP.gameObject.SetActive(true);
        rewardTextTMP.text = ("Gained ") + reward + (" Planks");
        inventory.planks += reward;

        gameIsWonTimer = 5;
        gameIsWon = true;
        winText.SetActive(true);
        canvasWoodCutter.SetActive(false);
        instructionText.SetActive(false);
        correctText.SetActive(false);

        // Unlock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cam.sensX = cam.savedSensX;
        cam.sensY = cam.savedSensY;

        CutWood();
    }

    // Called when the win timer reaches 0 to complete the win state
    void WinMiniGame()
    {
        inventory.hasWood = false;
        winText.SetActive(false);
        gameHasStarted = false;
        gameIsPlaying = false;
        gameIsWon = false;
        currentRound = 0;
        numberWrong = 0;
        timeBetweenRounds = -1;
        interactText.SetActive(true);
        rewardTextTMP.gameObject.SetActive(false);
        gameIsWonTimer = 5;

        Debug.Log("Won Wood Minigame");
    }

    void LoseMiniGame()
    {
        wrongText.SetActive(false);
        gameHasStarted = false;
        gameIsPlaying = false;
        currentRound = 0;
        numberWrong = 0;
        roundInProgress = false;
        interactText.SetActive(true);
        instructionText.SetActive(false);
        rewardTextTMP.gameObject.SetActive(false);
        timeBetweenRounds = -1;
        gameIsWonTimer = 5;
        canvasWoodCutter.SetActive(false);

        Debug.Log("Lost Wood Minigame");

        // Unlock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cam.sensX = cam.savedSensX;
        cam.sensY = cam.savedSensY;
    }

    // Function to control and store the cutting wood mechancis
    void CutWood()
    {
        if (beginCutting)
        {
            // Set wood to be active
            wood.SetActive(true);
            // Move wood accross the table in the correct direction
            wood.transform.position += new Vector3(0, 0, 0.5f * speed * Time.deltaTime);

            // Enable it so that audio plays when cutting
            FMODUnity.RuntimeManager.PlayOneShot("event:/wood cutting saw");
        }
    }
}
