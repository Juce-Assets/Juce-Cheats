using Juce.Cheats.WidgetsInteractors;

namespace Juce.Cheats.UseCases.RemoveWidget
{
    public interface IRemoveWidgetUseCase
    {
        void Execute(IWidgetInteractor widgetInteractor);
    }
}
