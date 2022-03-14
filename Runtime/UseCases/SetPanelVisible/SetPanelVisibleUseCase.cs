using Juce.Cheats.Panel;
using Juce.Cheats.Repositories;

namespace Juce.Cheats.UseCases.SetPanelVisible
{
    public class SetPanelVisibleUseCase : ISetPanelVisibleUseCase
    {
        private readonly ISingleRepository<CheatsPanelRoot> cheatsPanelRepository;

        public SetPanelVisibleUseCase(
            ISingleRepository<CheatsPanelRoot> cheatsPanelRepository
            )
        {
            this.cheatsPanelRepository = cheatsPanelRepository;
        }

        public void Execute(bool visible)
        {
            bool found = cheatsPanelRepository.TryGet(out CheatsPanelRoot cheatsPanelRoot);

            if(!found)
            {
                return;
            }

            cheatsPanelRoot.gameObject.SetActive(visible);
        }
    }
}
