using Juce.Cheats.Panel;
using Juce.Cheats.Repositories;
using Juce.Cheats.UseCases.SetPanelVisible;

namespace Juce.Cheats.UseCases.TogglePanelVisible
{
    public class TogglePanelVisibleUseCase : ITogglePanelVisibleUseCase
    {
        private readonly ISingleRepository<CheatsPanelRoot> cheatsPanelRepository;
        private readonly ISetPanelVisibleUseCase setPanelVisibleUseCase;

        public TogglePanelVisibleUseCase(
            ISingleRepository<CheatsPanelRoot> cheatsPanelRepository,
            ISetPanelVisibleUseCase setPanelVisibleUseCase
            )
        {
            this.cheatsPanelRepository = cheatsPanelRepository;
            this.setPanelVisibleUseCase = setPanelVisibleUseCase;
        }

        public void Execute()
        {
            bool found = cheatsPanelRepository.TryGet(out CheatsPanelRoot cheatsPanelRoot);

            if (!found)
            {
                return;
            }

            setPanelVisibleUseCase.Execute(!cheatsPanelRoot.gameObject.activeSelf);
        }
    }
}
