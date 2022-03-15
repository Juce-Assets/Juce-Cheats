using Juce.Cheats.Core;
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
            JuceCheats.AddToggle("Toggle", () => { return false; }, (bool enabled) => UnityEngine.Debug.Log(enabled));
        }
    }
}
