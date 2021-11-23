using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HeatController : MonoBehaviour
{
    public float currentTemperature;

    public bool heatState;
    public bool coldState;

    public float speed = 0.001f;

    public AnimationCurve heat;
    public AnimationCurve cold;
    public AnimationCurve none;

    public Slider slider;

    public UnityEvent<bool> OnChangeState;

    private bool isMax;

    public void ChangeHeatState(bool state)
    {
        heatState = state;
    }

    public void ChangeColdState(bool state)
    {
        coldState = state;
    }

    void Update()
    {
        var delta = 0f;
        if (heatState)
            delta += heat.Evaluate(currentTemperature);
        if (coldState)
            delta += cold.Evaluate(currentTemperature);
        delta += none.Evaluate(currentTemperature);

        currentTemperature = Mathf.Clamp(currentTemperature + delta * speed, 0, 1);
        slider.value = currentTemperature;

        if (currentTemperature >= 0.98f)
        {
            if (!isMax)
            {
                isMax = true;
                OnChangeState?.Invoke(isMax);
            }
        }
        else 
        {
            if(isMax)
            {
                isMax = false;
                OnChangeState?.Invoke(isMax);
            }
        }
    }
}
