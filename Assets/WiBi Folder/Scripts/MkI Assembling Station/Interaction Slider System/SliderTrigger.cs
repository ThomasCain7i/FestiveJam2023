using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderTrigger : MonoBehaviour
{

    [SerializeField] bool leftCollider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ISlider"))
        {
            Debug.Log("IS ISlider Found");
            if (leftCollider)
            {
                Collider c = other.gameObject.GetComponent<Collider>();
                if (c != null)
                {
                    Debug.Log("ISlider Collider Found");
                    c.gameObject.GetComponent<ButtonSlider>().moveLeft = false;
                    c.gameObject.GetComponent<ButtonSlider>().moveRight = true;
                }
            }
        }
    }
}
