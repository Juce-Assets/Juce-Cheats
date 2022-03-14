using UnityEngine;
using UnityEngine.UI;

namespace Juce.Cheats.Widgets
{
    public class ActionWidget : MonoBehaviour
    {
        [SerializeField] private Button button = default;
        [SerializeField] private TMPro.TextMeshProUGUI text = default;

        public Button Button => button;
        public TMPro.TextMeshProUGUI Text => text;
    }
}
