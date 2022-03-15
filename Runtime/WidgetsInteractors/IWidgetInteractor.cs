using UnityEngine;

namespace Juce.Cheats.WidgetsInteractors
{
    public interface IWidgetInteractor
    {
        GameObject Widget { get; }

        void Subscribe();
        void Unsubscribe();
        void Refresh();
    }
}
