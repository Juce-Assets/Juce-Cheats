using Juce.Cheats.Repositories;
using Juce.Cheats.WidgetsInteractors;

namespace Juce.Cheats.UseCases.RemoveWidget
{
    public class RemoveWidgetUseCase : IRemoveWidgetUseCase
    {
        private readonly IRepository<IWidgetInteractor> widgetInteractors;

        public RemoveWidgetUseCase(
            IRepository<IWidgetInteractor> widgetInteractors
            )
        {
            this.widgetInteractors = widgetInteractors;
        }

        public void Execute(IWidgetInteractor widgetInteractor)
        {
            bool found = widgetInteractors.Contains(widgetInteractor);

            if(!found)
            {
                return;
            }

            widgetInteractors.Remove(widgetInteractor);

            UnityEngine.Object.Destroy(widgetInteractor.Widget);
        }
    }
}
