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

    }
}
