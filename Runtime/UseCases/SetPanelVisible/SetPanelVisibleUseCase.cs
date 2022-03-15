using Juce.Cheats.Panel;
using Juce.Cheats.Repositories;
using Juce.Cheats.UseCases.RefreshAllWidgets;

namespace Juce.Cheats.UseCases.SetPanelVisible
{
    public class SetPanelVisibleUseCase : ISetPanelVisibleUseCase
    {
        private readonly ISingleRepository<CheatsPanelRoot> cheatsPanelRepository;
        private readonly IRefreshAllWidgetsUseCase refreshAllWidgetsUseCase;

        public SetPanelVisibleUseCase(
            ISingleRepository<CheatsPanelRoot> cheatsPanelRepository,
            IRefreshAllWidgetsUseCase refreshAllWidgetsUseCase
            )
        {
            this.cheatsPanelRepository = cheatsPanelRepository;
            this.refreshAllWidgetsUseCase = refreshAllWidgetsUseCase;
        }

        public void Execute(bool visible)
        {
            bool found = cheatsPanelRepository.TryGet(out CheatsPanelRoot cheatsPanelRoot);

            if(!found)
            {
                return;
            }

            if (visible)
            {
                refreshAllWidgetsUseCase.Execute();
            }

            cheatsPanelRoot.gameObject.SetActive(visible);
        }
    }
}
