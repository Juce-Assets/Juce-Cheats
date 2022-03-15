using Juce.Cheats.WidgetsInteractors;

namespace Juce.Cheats.UseCases.AddWidget
{
    public interface IAddWidgetUseCase
    {
        void Execute(IWidgetInteractor widgetInteractor);
    }
}
