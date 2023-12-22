using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool hasWood, hasMetal, hasCloth;
    public int planks, nails, wool;
    public TextMeshProUGUI woodText, metalText, clothText, planksText, nailsText, woolText;

    [SerializeField] BlueprintGiver blueprintGiver;
    [SerializeField] MinigameManager minigameManager;

    // Update is called once per frame
    void Update()
    {
        #region - If statements for colour of text -
        if (hasWood)
        {
            woodText.color = Color.green;
        }
        else
        {
            woodText.color = Color.red;
        }

        if (hasMetal)
        {
            metalText.color = Color.green;
        }
        else
        {
            metalText.color = Color.red;
        }

        if (hasCloth)
        {
            clothText.color = Color.green;
        }
        else
        {
            clothText.color = Color.red;
        }

        #endregion

        #region - How many of each materials text -
        planksText.text = "Plank: (" + planks.ToString() + ")";
        nailsText.text = "Nail: (" + nails.ToString() + ")";
        woolText.text = "Wool: (" + wool.ToString() + ")";
        #endregion

        if (blueprintGiver != null && minigameManager != null)
        {
            if (blueprintGiver.train && planks >= 2 && nails >= 5)
            {
                minigameManager.hasMatsBuild = true;
            }

            if (blueprintGiver.bear && wool >= 5)
            {
                minigameManager.hasMatsBuild = true;
            }
        }
    }
}
