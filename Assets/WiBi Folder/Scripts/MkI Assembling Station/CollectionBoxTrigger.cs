using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionBoxTrigger : MonoBehaviour
{
    [SerializeField] int childCount;
    [SerializeField] GameObject toySpawn;
    [SerializeField] bool toyMade;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Toy"))
        {
            Debug.Log("Toy Hit Trigger");
            Collider c = other.gameObject.GetComponent<Collider>();
            if (c != null)
            {
                Debug.Log("Toy Collected");
                c.gameObject.SetActive(false);
                c.gameObject.GetComponent<ToyDone>().toyDone = false;
                toyMade = true;
                Debug.Log("Toy Made!");
                if (toyMade)
                {
                    childCount = c.transform.childCount;
                    for (int i = 0; i < childCount; i++)
                    {
                        c.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    c.gameObject.SetActive(true);
                    c.gameObject.transform.position = toySpawn.transform.position;
                    c.gameObject.transform.rotation = toySpawn.transform.rotation;
                    toyMade = false;
                }
            }
        }
    }
}
