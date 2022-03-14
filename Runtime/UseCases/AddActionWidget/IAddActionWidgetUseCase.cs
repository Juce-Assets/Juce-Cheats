using Juce.Cheats.WidgetsInteractors;
using System;

namespace Juce.Cheats.UseCases.AddActionWidget
{
    public interface IAddActionWidgetUseCase
    {
        IWidgetInteractor Execute(string actionName, Action action);
    }
}
