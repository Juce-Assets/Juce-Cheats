using Juce.Cheats.Installers;
using Juce.Cheats.WidgetsInteractors;
using Juce.Utils.Singletons;
using System;

namespace Juce.Cheats.Core
{
    public class JuceCheats : AutoStartMonoSingleton<JuceCheats>
    {
        private bool inited;

        private CoreInteractor coreInteractor;

        private void InternalInit()
        {
            if(inited)
            {
                return;
            }

            inited = true;

            coreInteractor = new CoreInstaller().Install();

            coreInteractor.TrySpawnPanel();
        }

        public static void Open()
        {
            Instance.InternalInit();
            Instance.coreInteractor.SetPanelVisible(visible: true);
        }

        public static void Close()
        {
            Instance.InternalInit();
            Instance.coreInteractor.SetPanelVisible(visible: false);
        }

        public static void Toggle()
        {
            Instance.InternalInit();
            Instance.coreInteractor.TogglePanelVisible();
        }

        public static void Remove(IWidgetInteractor widgetInteractor)
        {
            Instance.InternalInit();
            Instance.coreInteractor.RemoveWidget(widgetInteractor);
        }

        public static IWidgetInteractor AddAction(string actionName, Action action)
        {
            Instance.InternalInit();
            return Instance.coreInteractor.AddActionWidget(actionName, action);
        }
    }
}
