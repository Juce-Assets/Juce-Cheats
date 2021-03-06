using Juce.Cheats.UseCases.AddActionWidget;
using Juce.Cheats.UseCases.AddToggleWidget;
using Juce.Cheats.UseCases.RefreshAllWidgets;
using Juce.Cheats.UseCases.RemoveWidget;
using Juce.Cheats.UseCases.SetPanelVisible;
using Juce.Cheats.UseCases.TogglePanelVisible;
using Juce.Cheats.UseCases.TrySpawnPanelPrefab;
using Juce.Cheats.WidgetsInteractors;
using System;

namespace Juce.Cheats.Installers
{
    public class CoreInteractor
    {
        private readonly ITrySpawnPanelPrefabUseCase trySpawnPanelPrefabUseCase;
        private readonly ISetPanelVisibleUseCase setPanelVisibleUseCase;
        private readonly ITogglePanelVisibleUseCase togglePanelVisibleUseCase;
        private readonly IRemoveWidgetUseCase removeWidgetUseCase;
        private readonly IAddActionWidgetUseCase addActionWidgetUseCase;
        private readonly IAddToggleWidgetUseCase addToggleWidgetUseCase;

        public CoreInteractor(
            ITrySpawnPanelPrefabUseCase trySpawnPanelPrefabUseCase,
            ISetPanelVisibleUseCase setPanelVisibleUseCase,
            ITogglePanelVisibleUseCase togglePanelVisibleUseCase,
            IRemoveWidgetUseCase removeWidgetUseCase,
            IAddActionWidgetUseCase addActionWidgetUseCase,
            IAddToggleWidgetUseCase addToggleWidgetUseCase
            )
        {
            this.trySpawnPanelPrefabUseCase = trySpawnPanelPrefabUseCase;
            this.setPanelVisibleUseCase = setPanelVisibleUseCase;
            this.togglePanelVisibleUseCase = togglePanelVisibleUseCase;
            this.removeWidgetUseCase = removeWidgetUseCase;
            this.addActionWidgetUseCase = addActionWidgetUseCase;
            this.addToggleWidgetUseCase = addToggleWidgetUseCase;
        }

        public void TrySpawnPanel()
        {
            trySpawnPanelPrefabUseCase.Execute();
        }

        public void SetPanelVisible(bool visible)
        {
            setPanelVisibleUseCase.Execute(visible);
        }

        public void TogglePanelVisible()
        {
            togglePanelVisibleUseCase.Execute();
        }

        public void RemoveWidget(IWidgetInteractor widgetInteractor)
        {
            removeWidgetUseCase.Execute(widgetInteractor);
        }

        public IWidgetInteractor AddActionWidget(string actionName, Action action)
        {
            return addActionWidgetUseCase.Execute(actionName, action);
        }

        public IWidgetInteractor AddToggleWidget(string actionName, Func<bool> getAction, Action<bool> setAction)
        {
            return addToggleWidgetUseCase.Execute(actionName, getAction, setAction);
        }
    }
}
