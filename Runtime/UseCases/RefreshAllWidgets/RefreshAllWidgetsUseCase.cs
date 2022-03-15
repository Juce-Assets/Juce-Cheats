using Juce.Cheats.Repositories;
using Juce.Cheats.WidgetsInteractors;

namespace Juce.Cheats.UseCases.RefreshAllWidgets
{
    public class RefreshAllWidgetsUseCase : IRefreshAllWidgetsUseCase
    {
        private readonly IRepository<IWidgetInteractor> widgetInteractors;

        public RefreshAllWidgetsUseCase(
            IRepository<IWidgetInteractor> widgetInteractors
            )
        {
            this.widgetInteractors = widgetInteractors;
        }

        public void Execute()
        {
            foreach(IWidgetInteractor widget in widgetInteractors.Items)
            {
                widget.Refresh();
            }
        }
    }
}
