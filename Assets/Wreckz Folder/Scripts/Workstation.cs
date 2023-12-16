using UnityEngine;

public class Workstation : MonoBehaviour
{
    [SerializeField] GameObject present1, present2, present3, grabArt;

    [SerializeField] Inventory inventory;

    [SerializeField] bool isInteractable;

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
            if (inventory.hasPresent1 && Input.GetKey(KeyCode.E))
            {
                present1.SetActive(true);
                present2.SetActive(false);
                present3.SetActive(false);
                inventory.hasPresent1 = false;
            }

            if (inventory.hasPresent2 && Input.GetKey(KeyCode.E))
            {
                present1.SetActive(false);
                present2.SetActive(true);
                present3.SetActive(false);
                inventory.hasPresent2 = false;
            }

            if (inventory.hasPresent3 && Input.GetKey(KeyCode.E))
            {
                present1.SetActive(false);
                present2.SetActive(false);
                present3.SetActive(true);
                inventory.hasPresent3 = false;
            }
        }
    }
}
