using Juce.Cheats.Widgets;
using UnityEngine;

namespace Juce.Cheats.Panel
{
    public class CheatsPanelRoot : MonoBehaviour, IContentParentProvider, IWidgetsProvider
    {
        [Header("Content")]
        [SerializeField] private Transform contentParent = default;

        [Header("Widgets")]
        [SerializeField] private ActionWidget actionWidget = default;
        [SerializeField] private ToggleWidget toggleWidget = default;

        public Transform ContentParent => contentParent;

        public ActionWidget ActionWidget => actionWidget;
        public ToggleWidget ToggleWidget => toggleWidget;
    }
}
