using Juce.Cheats.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCheatsExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            JuceCheats.Toggle();
            JuceCheats.AddAction("Action", () => { UnityEngine.Debug.Log("Pressed"); });
        }
    }
}
