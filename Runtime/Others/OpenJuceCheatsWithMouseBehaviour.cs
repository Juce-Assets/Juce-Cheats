using Juce.Cheats.Core;
using UnityEngine;

namespace Juce.Cheats.Others
{
    public class OpenJuceCheatsWithMouseBehaviour : MonoBehaviour
    {

#if DEVELOPMENT_BUILD || UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                JuceCheats.Toggle();
            }
        }
#endif

    }
}
