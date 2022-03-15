using UnityEngine;
using UnityEngine.UI;

namespace Juce.Cheats.Widgets
{
    public class ToggleWidget : MonoBehaviour
    {
        [SerializeField] private Button button = default;
        [SerializeField] private TMPro.TextMeshProUGUI text = default;
        [SerializeField] private GameObject toggleCheck = default;

        public Button Button => button;
        public TMPro.TextMeshProUGUI Text => text;
        public GameObject ToggleCheck => toggleCheck;
    }
}
