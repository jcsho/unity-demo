using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoColorChanger : MonoBehaviour
{

    Renderer renderer;
    float duration = 5f;

    Color startColor = Color.white;
    Color endColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        renderer.material.color = Color.Lerp(startColor, endColor, lerp);
    }
}
