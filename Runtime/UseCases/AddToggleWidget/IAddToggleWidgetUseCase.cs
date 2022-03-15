using Juce.Cheats.WidgetsInteractors;
using System;

namespace Juce.Cheats.UseCases.AddToggleWidget
{
    public interface IAddToggleWidgetUseCase
    {
        IWidgetInteractor Execute(string actionName, Func<bool> getAction, Action<bool> setAction);
    }
}
