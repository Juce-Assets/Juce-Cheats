using UnityEngine;

namespace Juce.Cheats.Widgets
{
    public interface IContentParentProvider
    {
        public Transform ContentParent { get; }
    }
}
