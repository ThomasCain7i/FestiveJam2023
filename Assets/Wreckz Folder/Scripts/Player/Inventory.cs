using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool hasWood, hasMetal, hasCloth;
    public int planks, nails, wool;
    public TextMeshProUGUI woodText, metalText, clothText, planksText, nailsText, woolText;

    // Update is called once per frame
    void Update()
    {
        woodText.text = "Wood: (" + hasWood.ToString() + ")";
        metalText.text = "Metal: (" + hasMetal.ToString() + ")";
        clothText.text = "Cloth: (" + hasCloth.ToString() + ")";
        planksText.text = "Plank: (" + planks.ToString() + ")";
        nailsText.text = "Nail: (" + nails.ToString() + ")";
        woolText.text = "Wool: (" + wool.ToString() + ")";
    }
}
