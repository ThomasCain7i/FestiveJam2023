using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float speed;
    [SerializeField] bool moveLeft;
    [SerializeField] bool moveRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SliderMove();
        SliderSwapDirection();
    }
    void SliderMove()
    {
        if (moveLeft)
        {
            slider.value += 5 * speed * Time.deltaTime;
        }
        if (moveRight)
        {
            slider.value -= 5 * speed * Time.deltaTime;
        }
    }


    void SliderSwapDirection()
    {
        if(slider.value == slider.minValue)
        {
            moveRight = false;
            moveLeft = true;
        }
        if (slider.value == slider.maxValue)
        {
            moveRight = true;
            moveLeft = false;
        }
    }
}
