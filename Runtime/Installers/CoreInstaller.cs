using Juce.Cheats.Panel;
using Juce.Cheats.Repositories;
using Juce.Cheats.UseCases.AddActionWidget;
using Juce.Cheats.UseCases.RemoveWidget;
using Juce.Cheats.UseCases.SetPanelVisible;
using Juce.Cheats.UseCases.TogglePanelVisible;
using Juce.Cheats.UseCases.TrySpawnPanelPrefab;
using Juce.Cheats.WidgetsInteractors;

namespace Juce.Cheats.Installers
{
    public class CoreInstaller
    {
        public CoreInteractor Install()
        {
            ISingleRepository<CheatsPanelRoot> cheatsPanelRepository = new SimpleSingleRepository<CheatsPanelRoot>();

            IRepository<IWidgetInteractor> widgetInteractorsRepository = new SimpleRepository<IWidgetInteractor>();

            ITrySpawnPanelPrefabUseCase trySpawnPanelPrefabUseCase = new TrySpawnPanelPrefabUseCase(
                cheatsPanelRepository
                );

            ISetPanelVisibleUseCase setPanelVisibleUseCase = new SetPanelVisibleUseCase(
                cheatsPanelRepository
                );

            ITogglePanelVisibleUseCase togglePanelVisibleUseCase = new TogglePanelVisibleUseCase(
                cheatsPanelRepository
                );

            IRemoveWidgetUseCase removeWidgetUseCase = new RemoveWidgetUseCase(
                widgetInteractorsRepository
                );

            IAddActionWidgetUseCase addActionWidgetUseCase = new AddActionWidgetUseCase(
                cheatsPanelRepository,
                widgetInteractorsRepository
                );

            return new CoreInteractor(
                trySpawnPanelPrefabUseCase,
                setPanelVisibleUseCase,
                togglePanelVisibleUseCase,
                removeWidgetUseCase,
                addActionWidgetUseCase
                );
        }
    }
}
