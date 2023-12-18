using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    public float speed;
    [SerializeField] bool moveLeft;
    [SerializeField] bool moveRight;

    // Update is called once per frame
    void Update()
    {
        SpeedDecreaser();
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
    void SpeedDecreaser()
    {
        if(speed >= 25)
        {
            speed -= 3f * Time.deltaTime;
        }
    }
}
