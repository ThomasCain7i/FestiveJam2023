using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float speed;
    public bool moveLeft;
    public bool moveRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value >= 0)
        {
            slider.value += 5 * speed * Time.deltaTime;
        }
        else if (slider.value < 0)
        {
            slider.value -= 5 * speed * Time.deltaTime;
        }
    }
}
