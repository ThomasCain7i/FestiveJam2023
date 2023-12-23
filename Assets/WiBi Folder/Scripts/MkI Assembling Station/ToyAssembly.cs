using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// This script was created by Liam Wilson
// For the purpose of actually assembling the toy, selected.

public class ToyAssembly : MonoBehaviour
{
    [Header("Script Variables")]
    [SerializeField] Slider assembleSlider;
    [SerializeField] GameObject canvas, interactionCanvas;
    [SerializeField] GameObject blueprintStation;
    public bool gameHasStarted;
    public int toyId;

    [Header("Toy Variables")]
    [SerializeField] GameObject toyKing;
    [SerializeField] GameObject toyParent;
    [SerializeField] int toyParentChildCount;
    [SerializeField] int toyArrayPos;
    [SerializeField] GameObject[] toyChildren;
    [SerializeField] bool hasShuffled;

    [Header("Input Variables")]
    [SerializeField] int arrayPos;
    [SerializeField] KeyCode[] codes;
    [SerializeField] KeyCode keyToBePressed;
    [SerializeField] TMP_Text display;
    [SerializeField] GameObject instrutionText, interactText;

    [Header("Toy Built Variables")]
    [SerializeField] GameObject player;
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject miniGameManager;

    private FMOD.Studio.EventInstance bells;

    private int max_steps;

    private int FMOD_step;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
        // Setting the key pressed to be R
        keyToBePressed = KeyCode.R;
        // Shuffling Arrays
        ShuffleArray(); ShuffleToy();
        // Sets canvas to be inactive.
        canvas.SetActive(false);

        bells = FMODUnity.RuntimeManager.CreateInstance("event:/assembling station chime");
        bells.setParameterByName("assembly step", 0);

        //max_steps = toyChildren.Length;

        FMOD_step = 0;

        max_steps = toyChildren.Length;
    }

    // Update is called once per frame
    void Update()
    {
        toyId = blueprintStation.GetComponent<BlueprintClicker>().blueprintId;
        // If ready to assemble
        if (gameHasStarted)
        {
            // Set slider canvas to be active
            interactionCanvas.SetActive(true);
            instrutionText.SetActive(true);
            interactText.SetActive(false);

            // Sets to parent to be the correct object from the king's children
            // based on the id collected from the blueprint object
            toyParent = toyKing.transform.GetChild(toyId).gameObject;
            // Grabs the total child count of the newly assigned toyParent
            toyParentChildCount = toyParent.transform.childCount;
            // Extends the toyChildren object array according to the total
            // amount of children the new toyParent has.
            toyChildren = new GameObject[toyParentChildCount];
            // Loops for the total amount of children the newly assigned
            // toyParent has, in order to assign all toyParent's children to the toyChildren
            // array for assembly once the player has collected enough materials
            for (int i = 0; i < toyParentChildCount; i++)
            {
                // Code to assign children to object arrat
                toyChildren[i] = toyParent.transform.GetChild(i).gameObject;
            }
            // Calling function to build the toy
            BuildToy();
        }
    }

    // Function to be called to build the train
    void BuildToy()
    {
        display.text = keyToBePressed.ToString();
        if(assembleSlider.value <= 10 && assembleSlider.value >= -10)
        {
            if (Input.GetKeyDown(keyToBePressed))
            {
                //FMODUnity.RuntimeManager.PlayOneShot("event:/assembly station chime");
                /*if(toyArrayPos >= max_steps) {
                    bells.start();
                    FMOD_step++;
                    bells.setParameterByName("assembly step", FMOD_step);
                }*/
                keyToBePressed = codes[arrayPos];
                arrayPos += 1;
                toyChildren[toyArrayPos].SetActive(true);
                toyArrayPos += 1;
                canvas.GetComponent<ButtonSlider>().speed = 100;
                FMODUnity.RuntimeManager.PlayOneShot("event:/assembling station");
                if (arrayPos >= 4)
                {
                    arrayPos = 0;
                    ShuffleArray();
                }
                if (toyArrayPos >= toyChildren.Length)
                {
                    toyArrayPos = 0;
                    gameHasStarted = false;
                    toyParent.GetComponent<ToyDone>().toyDone = true;
                    interactText.SetActive(true);
                    instrutionText.SetActive(false);
                    interactionCanvas.SetActive(false);
                    ToyBuilt();
                }
            }
        }
        else if (assembleSlider.value > 10 || assembleSlider.value < -10)
        {
            if (Input.GetKeyDown(keyToBePressed))
            {
                Debug.Log("Failed");
            }
        }
    }

    // Function to shuffle the input array for more randomness of keys
    void ShuffleArray()
    {
        for (int t = 0; t < codes.Length; t++)
        {
            KeyCode tmp = codes[t];
            int r = Random.Range(t, codes.Length);
            codes[t] = codes[r];
            codes[r] = tmp;
        }
    }

    // Function to shuffle the toy array for more randomness of construction
    void ShuffleToy()
    {
        for (int t = 0; t < toyChildren.Length; t++)
        {
            GameObject tmp = toyChildren[t];
            int r = Random.Range(t, toyChildren.Length);
            toyChildren[t] = toyChildren[r];
            toyChildren[r] = tmp;
        }
    }

    void ToyBuilt()
    {
        miniGameManager.GetComponent<MinigameManager>().hasMatsBuild = false;
        miniGameManager.GetComponent<MinigameManager>().hasMatsWrap = true;

        if(toyId == 0)
        {
            inventory.planks -= 3;
            inventory.nails -= 5;
        }
        else if (toyId == 1)
        {
            inventory.planks -= 6;
        }
        else if (toyId == 2)
        {
            inventory.nails -= 3;
            inventory.hasWood = false;
            inventory.wool -= 2;
        }
    }
}
