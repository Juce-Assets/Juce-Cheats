using Juce.Cheats.Panel;
using Juce.Cheats.Repositories;
using Juce.Cheats.UseCases.AddActionWidget;
using Juce.Cheats.UseCases.AddToggleWidget;
using Juce.Cheats.UseCases.AddWidget;
using Juce.Cheats.UseCases.RefreshAllWidgets;
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

            IRefreshAllWidgetsUseCase refreshAllWidgetsUseCase = new RefreshAllWidgetsUseCase(
                widgetInteractorsRepository
                );

            ISetPanelVisibleUseCase setPanelVisibleUseCase = new SetPanelVisibleUseCase(
                cheatsPanelRepository,
                refreshAllWidgetsUseCase
                );

            ITogglePanelVisibleUseCase togglePanelVisibleUseCase = new TogglePanelVisibleUseCase(
                cheatsPanelRepository,
                setPanelVisibleUseCase
                );

            IRemoveWidgetUseCase removeWidgetUseCase = new RemoveWidgetUseCase(
                widgetInteractorsRepository
                );

            IAddWidgetUseCase addWidgetUseCase = new AddWidgetUseCase(
                cheatsPanelRepository,
                widgetInteractorsRepository
                );

            IAddActionWidgetUseCase addActionWidgetUseCase = new AddActionWidgetUseCase(
                cheatsPanelRepository,
                addWidgetUseCase
                );

            IAddToggleWidgetUseCase addToggleWidgetUseCase = new AddToggleWidgetUseCase(
                cheatsPanelRepository,
                addWidgetUseCase
                );

            return new CoreInteractor(
                trySpawnPanelPrefabUseCase,
                setPanelVisibleUseCase,
                togglePanelVisibleUseCase,
                removeWidgetUseCase,
                addActionWidgetUseCase,
                addToggleWidgetUseCase
                );
        }
    }
}
