using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToyAssembly : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    public bool assemble;
    public int toySelected;

    [SerializeField] GameObject trainParent;
    [SerializeField] int trainArrayPos;
    [SerializeField] GameObject[] train;


    [SerializeField] int arrayPos;
    [SerializeField] int[] keys;
    [SerializeField] KeyCode[] codes;
    [SerializeField] KeyCode keyToBePressed;
    [SerializeField] TMP_Text display;
    // Start is called before the first frame update
    void Start()
    {
        keyToBePressed = KeyCode.Q;
        ShuffleArray(); ShuffleTrain();
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (assemble)
        {
            canvas.SetActive(true);
            if (toySelected == 0)
            {
                BuildTrain();
            }
        }
    }

    void BuildTrain()
    {
        display.text = keyToBePressed.ToString();
        if (Input.GetKeyDown(keyToBePressed))
        {
            keyToBePressed = codes[arrayPos];
            arrayPos += 1;
            train[trainArrayPos].SetActive(true);
            trainArrayPos += 1;
            if (arrayPos >= 4)
            {
                arrayPos = 0;
                ShuffleArray();
            }
            if (trainArrayPos >= train.Length)
            {
                trainArrayPos = 0;
                ShuffleTrain();
                assemble = false;
                canvas.SetActive(false);
                trainParent.GetComponent<ToyDone>().toyDone = true;
            }
        }
    }

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
    void ShuffleTrain()
    {
        for (int t = 0; t < train.Length; t++)
        {
            GameObject tmp = train[t];
            int r = Random.Range(t, keys.Length);
            train[t] = train[r];
            train[r] = tmp;
        }
    }
}
