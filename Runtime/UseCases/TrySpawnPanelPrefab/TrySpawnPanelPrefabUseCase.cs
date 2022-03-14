using Juce.Cheats.Core;
using Juce.Cheats.Panel;
using Juce.Cheats.Repositories;

namespace Juce.Cheats.UseCases.TrySpawnPanelPrefab
{
    public class TrySpawnPanelPrefabUseCase : ITrySpawnPanelPrefabUseCase
    {
        private readonly ISingleRepository<CheatsPanelRoot> cheatsPanelRepository;

        public TrySpawnPanelPrefabUseCase(
            ISingleRepository<CheatsPanelRoot> cheatsPanelRepository
            )
        {
            this.cheatsPanelRepository = cheatsPanelRepository;
        }

        public void Execute()
        {
            if(cheatsPanelRepository.HasItem)
            {
                return;
            }

            CheatsPanelRoot cheatsPanelRootPrefab = UnityEngine.Resources.Load<CheatsPanelRoot>("JuceCheatsPanel");

            if(cheatsPanelRootPrefab == null)
            {
                return;
            }

            CheatsPanelRoot cheatsPanelRoot = UnityEngine.Object.Instantiate(
                cheatsPanelRootPrefab,
                JuceCheats.Instance.transform, 
                worldPositionStays: false
                );

            if(cheatsPanelRoot == null)
            {
                return;
            }

            cheatsPanelRoot.gameObject.SetActive(false);

            cheatsPanelRepository.Set(cheatsPanelRoot);
        }
    }
}
