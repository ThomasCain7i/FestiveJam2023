using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// This script was created by Liam Wilson
// For the purpose of moving a slider,
// to create a little mini-game for the Assembly Station

public class ButtonSlider : MonoBehaviour
{
    [Header("Mini-Game Slider")]
    [SerializeField] Slider slider;
    [Header("Bool & Numbers")]
    public float speed;
    [SerializeField] bool moveLeft;
    [SerializeField] bool moveRight;

    // Update is called once per frame
    void Update()
    {
        // Calling all functions
        SpeedDecreaser();
        SliderMove();
        SliderSwapDirection();
    }
    // Function to control the movement of the slider
    void SliderMove()
    {
        if (moveLeft)
        {
            // Adds the slider's current to move the slider left
            slider.value += 5 * speed * Time.deltaTime;
        }
        if (moveRight)
        {
            // Subtracts the slider's current value to move right
            slider.value -= 5 * speed * Time.deltaTime;
        }
    }
    // Function to control when slider changes direction
    void SliderSwapDirection()
    {
        // if slider current value is qual tot the sliders min value
        if(slider.value == slider.minValue)
        {
            // Swap bools
            moveRight = false;
            moveLeft = true;
        }
        // if slider current value is equal to max value
        if (slider.value == slider.maxValue)
        {
            // Swap bools
            moveRight = true;
            moveLeft = false;
        }
    }
    // Function to control the decrease in speed, to make it easier.
    void SpeedDecreaser()
    {
        // Speed is less than or equal to 25
        if(speed >= 25)
        {
            // Decrease speed
            speed -= 3f * Time.deltaTime;
        }
    }
}
