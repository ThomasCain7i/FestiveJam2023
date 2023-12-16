using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] GameObject grabArt;

    [SerializeField] Inventory inventory;

    [SerializeField] bool isInteractable, wood, metal, cloth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            Debug.Log("Reach has entered");

            grabArt.SetActive(true);

            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            grabArt.SetActive(false);

            isInteractable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteractable)
        {
            if (wood && Input.GetKey(KeyCode.E) && !inventory.hasMetal && !inventory.hasCloth)
            {
                inventory.hasWood = true;
            }

            if (metal && Input.GetKey(KeyCode.E) && !inventory.hasWood && !inventory.hasCloth)
            {
                inventory.hasMetal = true;
            }

            if (cloth && Input.GetKey(KeyCode.E) && !inventory.hasWood && !inventory.hasMetal)
            {
                inventory.hasCloth = true;
            }
        }
    }
}
