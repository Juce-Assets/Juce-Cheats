using Juce.Cheats.Panel;
using Juce.Cheats.Repositories;
using Juce.Cheats.WidgetsInteractors;

namespace Juce.Cheats.UseCases.AddWidget
{
    public class AddWidgetUseCase : IAddWidgetUseCase
    {
        private readonly ISingleRepository<CheatsPanelRoot> cheatsPanelRepository;
        private readonly IRepository<IWidgetInteractor> widgetInteractors;

        public AddWidgetUseCase(
            ISingleRepository<CheatsPanelRoot> cheatsPanelRepository,
            IRepository<IWidgetInteractor> widgetInteractors
            )
        {
            this.cheatsPanelRepository = cheatsPanelRepository;
            this.widgetInteractors = widgetInteractors;
        }

        public void Execute(IWidgetInteractor widgetInteractor)
        {
            bool found = cheatsPanelRepository.TryGet(out CheatsPanelRoot cheatsPanelRoot);

            if (!found)
            {
                return;
            }

            widgetInteractor.Widget.transform.SetParent(cheatsPanelRoot.ContentParent);

            widgetInteractors.Add(widgetInteractor);

            widgetInteractor.Subscribe();
            widgetInteractor.Refresh();
        }
    }
}
