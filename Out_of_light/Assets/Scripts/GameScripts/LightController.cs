using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    private Light2D light;
    private bool lightOn = false;
    int randomNmber;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        InvokeRepeating("LightFilcker", 0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LightFilcker()
    {
        randomNmber = Random.Range(0, 5);
        Debug.Log(randomNmber);
        if (randomNmber == 3)
        {
            light.intensity = 1f;
            lightOn = true;
        } else
        {
            light.intensity = 0.05f;
        }
    }
}
