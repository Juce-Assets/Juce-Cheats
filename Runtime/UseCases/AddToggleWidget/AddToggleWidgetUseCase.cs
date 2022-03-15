using Juce.Cheats.Panel;
using Juce.Cheats.Repositories;
using Juce.Cheats.UseCases.AddWidget;
using Juce.Cheats.Widgets;
using Juce.Cheats.WidgetsInteractors;
using System;

namespace Juce.Cheats.UseCases.AddToggleWidget
{
    public class AddToggleWidgetUseCase : IAddToggleWidgetUseCase
    {
        private readonly ISingleRepository<CheatsPanelRoot> cheatsPanelRepository;
        private readonly IAddWidgetUseCase addWidgetUseCase;

        public AddToggleWidgetUseCase(
            ISingleRepository<CheatsPanelRoot> cheatsPanelRepository,
            IAddWidgetUseCase addWidgetUseCase
            )
        {
            this.cheatsPanelRepository = cheatsPanelRepository;
            this.addWidgetUseCase = addWidgetUseCase;
        }

        public IWidgetInteractor Execute(string actionName, Func<bool> getAction, Action<bool> setAction)
        {
            bool found = cheatsPanelRepository.TryGet(out CheatsPanelRoot cheatsPanelRoot);

            if (!found)
            {
                return NopActionWidgetInteractor.Instance;
            }

            ToggleWidget toggleWidget = UnityEngine.Object.Instantiate(
                cheatsPanelRoot.ToggleWidget,
                cheatsPanelRoot.ContentParent,
                worldPositionStays: false
                );

            ToggleWidgetInteractor interactor = new ToggleWidgetInteractor(
                toggleWidget,
                actionName,
                getAction,
                setAction
                );

            addWidgetUseCase.Execute(interactor);

            return interactor;
        }
    }
}
