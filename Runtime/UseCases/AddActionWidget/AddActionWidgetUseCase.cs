using Juce.Cheats.Panel;
using Juce.Cheats.Repositories;
using Juce.Cheats.Widgets;
using Juce.Cheats.WidgetsInteractors;
using System;

namespace Juce.Cheats.UseCases.AddActionWidget
{
    public class AddActionWidgetUseCase : IAddActionWidgetUseCase
    {
        private readonly ISingleRepository<CheatsPanelRoot> cheatsPanelRepository;
        private readonly IRepository<IWidgetInteractor> widgetInteractors;

        public AddActionWidgetUseCase(
            ISingleRepository<CheatsPanelRoot> cheatsPanelRepository,
            IRepository<IWidgetInteractor> widgetInteractors
            )
        {
            this.cheatsPanelRepository = cheatsPanelRepository;
            this.widgetInteractors = widgetInteractors;
        }

        public IWidgetInteractor Execute(string actionName, Action action)
        {
            bool found = cheatsPanelRepository.TryGet(out CheatsPanelRoot cheatsPanelRoot);

            if (!found)
            {
                return NopActionWidgetInteractor.Instance;
            }

            ActionWidget actionWidget = UnityEngine.Object.Instantiate(
                cheatsPanelRoot.ActionWidget,
                cheatsPanelRoot.ContentParent,
                worldPositionStays: false
                );

            ActionWidgetInteractor interactor = new ActionWidgetInteractor(
                actionWidget,
                actionName,
                action
                );

            widgetInteractors.Add(interactor);

            interactor.Subscribe();

            return interactor;
        }
    }
}
