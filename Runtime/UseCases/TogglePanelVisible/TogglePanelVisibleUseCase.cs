using Juce.Cheats.Panel;
using Juce.Cheats.Repositories;

namespace Juce.Cheats.UseCases.TogglePanelVisible
{
    public class TogglePanelVisibleUseCase : ITogglePanelVisibleUseCase
    {
        private readonly ISingleRepository<CheatsPanelRoot> cheatsPanelRepository;

        public TogglePanelVisibleUseCase(
            ISingleRepository<CheatsPanelRoot> cheatsPanelRepository
            )
        {
            this.cheatsPanelRepository = cheatsPanelRepository;
        }

        public void Execute()
        {
            bool found = cheatsPanelRepository.TryGet(out CheatsPanelRoot cheatsPanelRoot);

            if (!found)
            {
                return;
            }

            cheatsPanelRoot.gameObject.SetActive(!cheatsPanelRoot.gameObject.activeSelf);
        }
    }
}
